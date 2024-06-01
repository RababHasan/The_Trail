using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Assign your clips here in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioSequentially());
    }

    System.Collections.IEnumerator PlayAudioSequentially()
    {
        yield return null;

        // Loop through each audio clip
        foreach (var audioClip in audioClips)
        {
            // Set the clip and play
            audioSource.clip = audioClip;
            audioSource.Play();

            // Wait for it to finish playing
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            // Optionally wait a bit before the next clip
            yield return new WaitForSeconds(1f);
        }
    }
}

