using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Asset" , fileName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    //First node of the conversation
    public DialogueNode RootNode;
   
}
