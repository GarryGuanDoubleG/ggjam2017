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

    public bool[] weaponsEnabled;

    void OnEnable()
    {
        SoundManager.on_SRT += OnHearSound;
    }

    void OnDisable()
    {
        SoundManager.on_SRT -= OnHearSound;
    }

    void Start()
    {
        myId = nextId++;
        haveEnemyFlag = false;

        my_flag.myId = myId;
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
        //appy sound information
    }

    public void Death()
    {
        Vector3 start_pad_pos = my_startpad.transform.position;
        start_pad_pos.y += .3f;
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
    public void Respawn()
    {
        Debug.Log("Respawn");
        Vector3 start_pad_pos = my_startpad.transform.position;
        
        start_pad_pos.y += .3f;//go up a litte bit

        transform.position = start_pad_pos;
        transform.rotation = Quaternion.identity;//set up 0
    }
}