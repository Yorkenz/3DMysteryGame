using UnityEngine;

[system.Serializable]
public class DialogueNode : MonoBehaviour
{
  public string dialogueText;
  public list<DialogueResponse> responses;

    internal bool IsLastNode()
    {
        return responses.count == 0;
    }
}
