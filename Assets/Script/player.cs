using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public static int nextId = 0;
    public int myId;
    public bool haveEnemyFlag;

    public Flag my_flag;
    public GameObject my_startpad;

    void OnEnable()
    {
        SoundManager.on_SRT += OnHearSound;
    }

    void OnDisable()
    {
        SoundManager.on_SRT -= OnHearSound;
    }

    void OnCollisionEnter(Collision col)
    {
        
    }

    void Start()
    {
        myId = nextId++;
        haveEnemyFlag = false;
        Debug.Log("Id is " + myId);
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

    public void Death()
    {
        transform.position = my_startpad.transform.position;
        transform.rotation = my_startpad.transform.rotation;

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.tag != "flag")
            {
                Destroy(child.gameObject);
            }
            else
            {
                child.transform.parent = null;
            }
        }

    }
}