using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private float health;
    public string dialogueObject;
    public string dialogueLooks;
    public string dialogueDangers;

    public bool isGrabbed;
}