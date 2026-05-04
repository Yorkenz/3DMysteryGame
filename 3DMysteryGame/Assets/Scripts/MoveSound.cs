using UnityEngine;

public class MoveSound : MonoBehaviour
{
    public AudioSource moveSound;
    public float threshold = 0.01f; // Minimum distance to consider "moving"
    private Vector3 lastPosition;

    void Start() => lastPosition = transform.position;

    void Update()
    {
        // Calculate the distance moved since last frame
        float movement = Vector3.Distance(transform.position, lastPosition);

        if (movement > threshold)
        {
            if (!moveSound.isPlaying) moveSound.Play();
        }
        else
        {
            if (moveSound.isPlaying) moveSound.Stop();
        }

        lastPosition = transform.position;
    }
}
