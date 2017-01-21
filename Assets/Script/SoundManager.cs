using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//an Event Manager that calls a delegate on an event
public class SoundManager : MonoBehaviour {

    public delegate void SoundReachesTarget(float distance, Sound sound);//fill in relevant parametes
    public static event SoundReachesTarget on_SRT;

    public static float sound_speed = 340.29f;//meters per second

    void OnCollisionEnter(Collision collider)
    {
        float distance = Vector3.Distance(collider.transform.position, transform.position);

        StartCoroutine(UseDelegateAtTime(distance, collider.gameObject.GetComponent<Sound>()));

        Debug.Log("Player collision");
    }

    public IEnumerator UseDelegateAtTime(float distance, Sound sound)
    {
        float time_left = distance / sound_speed;
        //wait until time left is < 0
        for (float timer = 0; timer < time_left; timer += Time.deltaTime)
        {
            yield return null;
        }

        sound.playSound();
        on_SRT(distance, sound);

        yield break;
    }

}
