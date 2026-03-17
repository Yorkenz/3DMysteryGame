using UnityEngine;
using TMPro;
using System.Threading;
using unityEngine.UI;

public class DialogueManger : MonoBehaviour
{
 public DialogueManger instance {  get; private set; }
    //UI elements
    public GameObject DialogueParent;//Main container for the dialogue UI
    public TextMeshProUGUI DialogueTitleText, DialogueText;//Text component for Title and the dialogue text
    public GameObject responseButtonContainer;//Container to hold the response button 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
        //initially hide the dialogue UI
        HideDialogue();
    }

    //start the dialogue with given Title and Dialogue Node
    public void StartDialogue(string title, DialogueNode Node)
    {
        //Display the Dialogue UI
        ShowDialogue();

        //set Dialogue Title and Text
        DialogueTitleText.text = title;
        DialogueText.text = Node.dialogueText;
        
        // remove any existing response buttons
        foreach (Transform child in responseButtonContainer)
        {
            Destroy(child.gameObject);
        }

        //create and setup response buttons based on the current dialogue node 
        foreach (DialogueResponse response in Node.response)
        {
            GameObject buttonObj = instantiate(responseButtonPrefab, responseButtonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;

            //setup button to trigger selectResponse when clicked 
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response, title));
        }
    }

    //Handle response selection and triggers the next dialogue node
    public void SelectResponse(DialogueResponse response, string title)
    {
        // Check if there's a follow-up node 
        if (response.nextNode.IsLastNode)
        {
            StartDialogue(title, response.nextNode); // start Next Dialogue
        }
        else
        {
            HideDialogue();
        }
    }

    //Hide the dialogue UI
    public void HideDialogue()
    {
        DialogueParent.SetActive(false);
    }

    //Show the dialogue UI
    public void ShowDialogue()
    {
        DialogueParent.SetActive(true);
    }
}
