using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
public class Actor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;
    public void SpeakTo()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        DialogueManager.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}