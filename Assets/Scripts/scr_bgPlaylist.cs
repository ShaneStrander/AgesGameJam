using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bgPlaylist : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSong();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        currentSongIndex = (currentSongIndex + 1) % songs.Length;
    }
}
