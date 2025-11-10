using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{


    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
