using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public AudioSource musicSource;

    public void ToggleMusic()
    {
        if (musicSource == null)
        {
            Debug.LogError("Music Source is not assigned!");
            return;
        }

        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.Play();
    }
}