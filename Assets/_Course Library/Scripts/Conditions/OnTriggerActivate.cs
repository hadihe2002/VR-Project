using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    [Tooltip("The object to activate/deactivate when the player enters/exits this trigger")]
    public GameObject objectToToggle;

    [Tooltip("Tag of the GameObject that should trigger this. For XR rigs, you might tag your camera rig or controller as \"Player\".")]
    public string triggeringTag = "Player";

    private void Reset()
    {
        // Auto-add a BoxCollider if missing, and set to trigger
        var bc = GetComponent<BoxCollider>();
        if (bc == null) bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HEllo");

        if (other.CompareTag(triggeringTag))
        {
            objectToToggle.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            objectToToggle.SetActive(false);
        }
    }
}
