using UnityEngine;
using System.Collections;

public class VisualClue : MonoBehaviour
{
    private Material objectMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;

        StartCoroutine(GlowRoutine(true));
    }

    public void SetGlow(bool enable, Color glowColor, float intensity = 1f)
    {
        if (enable)
        {
            objectMaterial.SetColor("_EmissionColor", glowColor * intensity);
            objectMaterial.EnableKeyword("_EMISSION");
        }
        else
        {
            objectMaterial.DisableKeyword("_EMISSION");
        }
    }
    IEnumerator GlowRoutine(bool startGlowing)
    {
        if (startGlowing)
        {
            float duration = 2.0f;
            float startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                // PingPong for a smooth back and forth effect
                float intensity = Mathf.PingPong(t, 0.5f) + 0.5f;
                // Set the glow color to a bright green with varying intensity
                SetGlow(true, Color.blue, intensity * 3f);
                yield return null;
            }
        }
    }
}
