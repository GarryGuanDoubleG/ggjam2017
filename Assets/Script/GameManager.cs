using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public float pre_round_length;// 30 seconds to place the flag before the round begins

    public float round_timer;
    private bool round_started; //used to tell if we're in pre-round mode
 
    public Player player1;
    public Player player2;

    public GameObject p1Flag;
    public GameObject p2Flag;

    public GameObject p1StartPad;
    public GameObject p2StartPad;

	// Use this for initialization
	void Start () {
		StartPreRound();
	}
	
	// Update is called once per frame
	void Update () {
        if(!round_started)
        {
            round_timer -= Time.deltaTime;
            if(round_timer <= 0)
            {
                round_started = true;
                StartRound();
                round_timer = pre_round_length;
            }
           
        }

	}

    void StartRound()
    {
        if(!player1)
            return;
        //set player locations to where they dropped their flag
        p1Flag.transform.parent = null;
        player1.transform.position = p1StartPad.transform.position;
        player1.transform.rotation = p1StartPad.transform.rotation;

        if (!player2)
            return;
        //set player locations to where they dropped their flag
        p2Flag.transform.parent = null;
        player2.transform.position = p2StartPad.transform.position;
        player2.transform.rotation = p2StartPad.transform.rotation;
    }

    void StartPreRound()
    {
        round_timer = pre_round_length;
        round_started = false;
        //decide where to spawn players
    }


}
