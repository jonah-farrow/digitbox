using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // this was helped by https://www.youtube.com/watch?v=_5BnLwnKGa4
public class OpenSesame : MonoBehaviour
{
    [SerializeField] private GameObject movingDoor; // door asset to move
    [SerializeField] private GameObject levelExitSensor; // exit sensor
    private float maximumOpening = 10f; // door open distnace
    private float maximumClosing = 0f; // door closing distance
     
    private float movementSpeed = 5f; // how fast door moves
     
    private bool playerIsHere = false; // is player in sensor
     
    // Start is called before the first frame update
    void Start()
    {
        //playerIsHere = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(playerIsHere){ // if player is colliding
            if(movingDoor.transform.localPosition.y < maximumOpening){ // if the door is closed 
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f); // open the door
            }
        }else{
            if(movingDoor.transform.localPosition.y > maximumClosing){ // if the door is open
                movingDoor.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f); // close the door
            }
        } 
    }
     
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){ // if sensor collide with player
            playerIsHere = true; // player is here
            levelExitSensor.GetComponent<CloseSesame>().enabled = false; // disable close door script (keep door open)
        }
    }
     
    private void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){ // if exit with player
            playerIsHere = false; // player is no longer here
            levelExitSensor.GetComponent<CloseSesame>().enabled = true; // shut the door
        }
    }
}
