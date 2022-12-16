using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // this was helped by https://www.youtube.com/watch?v=_5BnLwnKGa4
public class CloseSesame : MonoBehaviour
{
    [SerializeField] private GameObject movingDoor; // door asset to move
    [SerializeField] private GameObject levelEntranceSensor; // exit sensor
    private float maximumOpening = 10f; // door open distnace
    private float maximumClosing = 0f; // door closing distance
     
    private float movementSpeed = 5f; // how fast door moves
     
    private bool playerIsHere2 = false; // is player in sensor
     
    // Start is called before the first frame update
    void Start()
    {
        //playerIsHere2 = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(playerIsHere2){ // if player is colliding
            if(movingDoor.transform.localPosition.y < maximumOpening){    // if the door is closed         
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f); // open the door
            }
        }else{
            if(movingDoor.transform.localPosition.y > maximumClosing){ // if the door is open
                movingDoor.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f); // close the door
            }
        } 
    }
     
    private void OnTriggerEnter(Collider col2){
        if(col2.gameObject.tag == "Player"){ // if sensor collide with player
            playerIsHere2 = true; // player is here
            levelEntranceSensor.GetComponent<OpenSesame>().enabled = false; // disable close door script (keep door open)
        }
    }
     
    private void OnTriggerExit(Collider col2){
        if(col2.gameObject.tag == "Player"){ // if exit with player
            playerIsHere2 = false; // player is no longer here
            levelEntranceSensor.GetComponent<OpenSesame>().enabled = true; // shut the door
        }
    }
}
