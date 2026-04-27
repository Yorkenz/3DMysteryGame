using TMPro;
using UnityEngine;

public class triggerNewAction : MonoBehaviour
{
    public TextMeshProUGUI TextTriggerOff;
    public TextMeshProUGUI TextTriggerOn;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TextTriggerOn.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextTriggerOff.gameObject.SetActive(false);
            TextTriggerOn.gameObject.SetActive(true);
        }
    }
}
