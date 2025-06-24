using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    
    public AudioClip[] soundClips;
    private AudioClip clipToPlay;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playAudio(string planetAudioName)
    {
        Debug.Log("audio name pass: " + planetAudioName);
        foreach (AudioClip clip in soundClips) // null check here. 
        {
            if (clip.name == planetAudioName)
            {
                clipToPlay = clip;
                break;
            }
            else
            {
                Debug.Log("No sound available");
            }
        }

        audio.PlayOneShot(clipToPlay, 1);


        // code should check to see if already playing something and cancel it if so. 

    }
}
