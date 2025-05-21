using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Interactions;

public class ButtonsTogether : MonoBehaviour
{
    [Tooltip("Add two or more Button-type actions here (embedded in this component).")]
    [SerializeField] private InputAction[] actions;

    public UnityEvent onAllPressed;     // fires once when every button is down
    public UnityEvent onAnyReleased;    // fires once when the combo breaks

    /* ------------------ life-cycle ------------------ */

    private void OnEnable()
    {
        foreach (var a in actions)
        {
            a.performed += OnPerformed;   // button crossed the press threshold
            a.canceled += OnCanceled;    // button released
            a.Enable();                   // IMPORTANT - start listening
        }
    }

    private void OnDisable()
    {
        foreach (var a in actions)
        {
            a.performed -= OnPerformed;
            a.canceled -= OnCanceled;
            a.Disable();
        }
    }

    /* ------------------ callbacks ------------------- */

    private void OnPerformed(InputAction.CallbackContext _)
    {
        if (AllPressed())           // have we just reached the full set?
            onAllPressed.Invoke();
    }

    private void OnCanceled(InputAction.CallbackContext _)
    {
        if (!AllPressed())          // have we just LEFT the full set?
            onAnyReleased.Invoke();
    }

    private bool AllPressed()
    {
        foreach (var a in actions)
        {
            if (a.phase != InputActionPhase.Performed)     // IsPressed() works for any button interaction
                return false;
        }

        return true;
    }
}
