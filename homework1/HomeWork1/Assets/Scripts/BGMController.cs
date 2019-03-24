using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

    private AudioSource audioSource;
    private bool muteState;
    private float preVolume;
    public AudioClip[] bgms;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();      
        muteState = false;
        preVolume = audioSource.volume;
    }
    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;
        muteState = false;
    }
    public void MuteClick()
    {
        muteState = !muteState;
        if (muteState)
        {
            preVolume = audioSource.volume;
            audioSource.volume = 0;
        }
        else
            audioSource.volume = preVolume;
    }
    public void ConsoleResult(int value)
    {
        switch (value)
        {
            case 0:
                this.GetComponent<AudioSource>().clip = bgms[0];
                this.GetComponent<AudioSource>().Play();
                break;
            case 1:
                this.GetComponent<AudioSource>().clip = bgms[1];
                this.GetComponent<AudioSource>().Play();
                break;
            case 2:
                this.GetComponent<AudioSource>().clip = bgms[2];
                this.GetComponent<AudioSource>().Play();
                break;
        }
    }
}
