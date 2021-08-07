
using System;

using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioClip[] clips;

    public static AudioManager instance;
    private void Awake () {

        if (instance == null) {

            instance = this;
            DontDestroyOnLoad(gameObject);

        } else {

            Destroy(gameObject);
        }
    }

    private void Start () {

        audioSource = GetComponent<AudioSource>();

        Debug.Log("Total Clips: " + clips.Length);
    }

    private AudioSource audioSource;

    private void PlaySound (string soundName) {

        AudioClip clip = Array.Find(clips, clipSearch => clipSearch.name == soundName);

        if (clip == null) {

            Debug.LogWarning("AudioManager: Sound '" + soundName + "' does not exist!");
            return;
        }

        audioSource.clip = clip;

        audioSource.pitch = UnityEngine.Random.Range(0.68f, 1.32f);

        audioSource.Play();
    }

    public static void Play (string soundName) {

        instance.PlaySound(soundName);
    }
}
