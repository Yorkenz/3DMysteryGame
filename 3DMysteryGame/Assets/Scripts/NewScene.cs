using UnityEngine;

public class NewScene : MonoBehaviour
{
   public string SceneName;
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
}
