using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTalk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 5f))
            {
                Actor actor = hitInfo.collider.GetComponent<Actor>();
                if (actor != null)
                {
                    actor.SpeakTo();
                }
            }
        }
    }
}
