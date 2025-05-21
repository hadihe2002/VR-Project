using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.Interaction.Toolkit.XRBaseControllerInteractor;

public class SelectTriggerChange : MonoBehaviour
{
    public XRRayInteractor ray;
    public InputTriggerType defaultMode = InputTriggerType.Toggle;

    void Awake()
    {
        defaultMode = ray.selectActionTrigger;
        ray.hoverEntered.AddListener(OnHoverEntered);
        ray.hoverExited.AddListener(OnHoverExited);
    }

    void OnDestroy()
    {
        ray.hoverEntered.RemoveListener(OnHoverEntered);
        ray.hoverExited.RemoveListener(OnHoverExited);
    }

    void OnHoverEntered(HoverEnterEventArgs args)
    {
        // if the thing we're pointing at is a teleportable area or anchor...
        if (args.interactableObject is BaseTeleportationInteractable)
            ray.selectActionTrigger = InputTriggerType.State;
    }

    void OnHoverExited(HoverExitEventArgs args)
    {
        if (args.interactableObject is BaseTeleportationInteractable)
            ray.selectActionTrigger = defaultMode;
    }
}
