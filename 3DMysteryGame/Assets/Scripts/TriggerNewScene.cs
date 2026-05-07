using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNewScene : MonoBehaviour
{   
    [SerializeField] private string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("triggered");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
