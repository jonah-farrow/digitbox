using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    private float countdownTimerDuration;
    private float countdownTimerStartTime; 

	// Use this for initialization
	void Start () {
        CountdownTimerReset(30);

	}
	
	// Update is called once per frame
	void Update () {

        int timeLeft = (int)CountdownTimerSecondsRemainng();

        if (timeLeft > 0) {
            Debug.Log("Countdown Seconds remianing = " + timeLeft.ToString());

        }
		
	}


    private void CountdownTimerReset (float delayInSeconds){
        countdownTimerDuration = delayInSeconds;
        countdownTimerStartTime = Time.time;

    }


    private float CountdownTimerSecondsRemainng(){
        float elapseSeconds = Time.time - countdownTimerStartTime;
        float timeLeft = countdownTimerDuration - elapseSeconds;

        return timeLeft;
    }


    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone 
        //has a tag called "Pick Up"
        if (other.gameObject.CompareTag("coin"))
        {
            //deactivat the other object
            other.gameObject.SetActive(false);

        }
    }


}
