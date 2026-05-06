using UnityEngine;

public class triggerGameObject : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToDisable != null) objectToDisable.SetActive(false);
            if (objectToEnable != null) objectToEnable.SetActive(true);
        }
    }
}
