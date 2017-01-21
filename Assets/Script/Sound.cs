using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//container class that stores audio clip to be played
public class Sound  : MonoBehaviour
{
    static const float sound_speed = 340.29f;//meters per second

    AudioSource sound;
    public float intensity;
    public float cooldown;
    public float play_rate = .5f;

    delegate void MyDelegate(int num);

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;

        cooldown = 0.0f;

        Debug.Log("Start up cube ");
    }

    public void playSound(Transform target)
    {
        cooldown -= Time.deltaTime;

        if (cooldown > 0) 
            return;

        // last parameter volume can be adjusted through rolloff in 3d sound settings
        AudioSource.PlayClipAtPoint(sound.clip, transform.position, 1);
        cooldown = play_rate;
    }

    void OnCollisionEnter(Collision col)
    {

    }


    void OnCollisionStay(Collision col)
    {

    }

    void OnTriggerStay(Collider col)
    {
        playSound(col.transform);
    }
}

public class SoundManager
{
    public delegate void SoundReachesTarget();//can be filled out with amplitude, volume, angle, etc.
    public IEnumerator UseDelegateAtTime(SoundReachesTarget srt_method, float time_left)
    {

        //wait until time left is < 0
        for (float timer = 0; timer < time_left; timer += Time.deltaTime)
        {
            yield return null;
        }

        srt_method();//run  the delegate when sound reaches the target

        yield break;
    }


}