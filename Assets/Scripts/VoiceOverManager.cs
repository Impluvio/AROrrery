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
        //Debug.Log("audio name pass: " + planetAudioName);
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


        if (audio.isPlaying)
        {
            audio.Stop();
            audio.PlayOneShot(clipToPlay, 1);
        }
        else if (!audio.isPlaying)
        {
            audio.PlayOneShot(clipToPlay, 1);
        }




        // code should check to see if already playing something and cancel it if so. 
        // toggle sound option in ui

    }

    public void stopAudio(string planetAudioName)
    {
        if(clipToPlay.name == planetAudioName)
        {
            audio.Stop();
        }
    }

}
