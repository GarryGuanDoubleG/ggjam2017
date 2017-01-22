using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour {

    public bool is_opened;

    void Start()
    {
        is_opened = false;
    }

    public IEnumerator RotateTop(Transform top, Transform pivot)
    {
        float duration = 1.0f;
        float rotation = 60.0f;
        float total_rotation = 0;

       
        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            float curr_rotation = rotation * Time.deltaTime;
            top.RotateAround(pivot.position, pivot.right, -curr_rotation);

            total_rotation += curr_rotation;
            yield return null;
        }

        top.RotateAround(pivot.position, pivot.right, -(rotation - total_rotation));

        yield break;
    }


    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "MainCamera"))
        {
            if (is_opened)
                return;
            else
                is_opened = true;
        }

        Transform top = transform.Find("Top");
        Transform pivot = transform.Find("Rotate");
        StartCoroutine(RotateTop(top, pivot));
    }


}
