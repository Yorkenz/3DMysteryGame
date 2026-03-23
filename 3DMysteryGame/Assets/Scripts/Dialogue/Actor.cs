using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;
    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            SpeakTo();
        } 
    }
    private void SpeakTo()
    {
        DialogueManager.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}