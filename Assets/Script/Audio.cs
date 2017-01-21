using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//container class that stores audio clip to be played
public class Sound  : MonoBehaviour
{
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
    }

    void OnCollisionEnter()
    {
        sound.Play();
    }

}
