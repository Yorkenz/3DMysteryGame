using UnityEngine;

public class Actor : MonoBehaviour
{
    public string name;
    public Dialogue Dialogue;

    private void update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpeakTo();
        }
    }
    // this triggers the dialogue for the actor.
    public void SpeakTo()
    {
        Dialogue.Instance.StartDialogue(name, Dialogue.RootNode);
    }
}
