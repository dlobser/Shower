using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component from the game object
        audioSource = GetComponent<AudioSource>();
        
        // Ensure there is an AudioSource to play the clip
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the game object.");
        }
        else if (soundToPlay == null)
        {
            Debug.LogError("No AudioClip assigned to soundToPlay in the inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is a first-person character
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");

            // Play the sound if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundToPlay;
                audioSource.Play();
            }
        }
    }
}
