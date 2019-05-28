using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     AudioSource environmentAudio;

    public AudioClip[] growthClips;
    public AudioClip[] shrinkClips;
    
    void Awake()
    {
        environmentAudio = GetComponent<AudioSource>();
    }

    public void GrowthSound (AudioSource playerAudioSource)
    {
        playerAudioSource.clip = growthClips[Random.Range(0, growthClips.Length)];
        playerAudioSource.Play();
    }

    public void ShrinkingSound(AudioSource playerAudioSource)
    {
        playerAudioSource.clip = shrinkClips[Random.Range(0, shrinkClips.Length)];
        playerAudioSource.Play();
    }

}
