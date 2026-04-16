using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    private Transform position;
    private bool playerInRange;
    private PlayerInput playerInput;
    public InputActionReference Action;
    private void Start() { 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            position = player.transform;
        }
    }
    private void Update() { 
        if(Action.action.IsPressed() && playerInRange) { 
            LoadScene();
        }
    }
    private void OnTriggerEnter(Collider other) { 
        if (other.CompareTag("Player")) { 
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) { 
        if (other.CompareTag("Player")) { 
            playerInRange = false;
        }
    }

    public string SceneName;
    public void LoadScene() { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
