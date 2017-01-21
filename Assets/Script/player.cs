using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    public int id;

    void OnEnable()
    {
        SoundManager.on_SRT += OnHearSound;
    }

    void OnDisable()
    {
        SoundManager.on_SRT -= OnHearSound;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void OnHearSound(float distance, Sound sound)
    {
        Debug.Log("Distance " + distance);
        Debug.Log("frequency" + sound.frequency);
    }
}