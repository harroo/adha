
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

            //idk why i put this here ik its lazy lmao
            Application.targetFrameRate = 16;

        } else {

            Destroy(gameObject);
        }
    }

    private void Start () {

        Debug.Log("Total Clips: " + clips.Length);
    }

    public AudioSource audioSource, voiceSource;

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

    private void PlayVoiceSound (string soundName) {

        AudioClip clip = Array.Find(clips, clipSearch => clipSearch.name == soundName);

        if (clip == null) {

            Debug.LogWarning("AudioManager: Sound '" + soundName + "' does not exist!");
            return;
        }

        voiceSource.clip = clip;

        voiceSource.pitch = UnityEngine.Random.Range(1.0f, 1.32f);

        voiceSource.Play();
    }
    private void StopVoiceSound () {

        voiceSource.Stop();
    }

    public static void Play (string soundName) {

        instance.PlaySound(soundName);
    }

    public static void PlayVoice (string soundName) {

        instance.PlayVoiceSound(soundName);
    }
    public static void StopVoice () {

        instance.StopVoiceSound();
    }
}
