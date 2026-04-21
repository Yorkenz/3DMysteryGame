using UnityEngine;
using UnityEngine.UI; // Required to access the Image component

public class ProgressHandler : MonoBehaviour
{
    public Image fillImage;

    public void UpdateProgress(float current, float max)
    {
        // fillAmount requires a float between 0 and 1
        fillImage.fillAmount = current / max;
    }
}
