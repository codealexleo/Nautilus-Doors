using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    public AudioClip background;

    // Static variable to keep track of the instance
    private static BackgroundMusic instance;

    private void Awake()
    {
        // Check if an instance of BackgroundMusic already exists
        if (instance != null && instance != this)
        {
            // If another instance exists, destroy this new one to avoid duplicates
            Destroy(gameObject);
        }
        else
        {
            // Set this as the instance and prevent it from being destroyed on load
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Set the background music clip and play it if not already playing
            if (backgroundMusic != null && !backgroundMusic.isPlaying)
            {
                backgroundMusic.clip = background;
                backgroundMusic.Play();
            }
        }
    }
}
