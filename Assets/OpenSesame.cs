using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    [SerializeField] private GameObject movingDoor;
    [SerializeField] private GameObject levelExitSensor;
    private float maximumOpening = 10f;
    private float maximumClosing = 0f;
     
    private float movementSpeed = 5f;
     
    private bool playerIsHere = false;
     
    // Start is called before the first frame update
    void Start()
    {
        //playerIsHere = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(playerIsHere){
            if(movingDoor.transform.localPosition.y < maximumOpening){
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }else{
            if(movingDoor.transform.localPosition.y > maximumClosing){
                movingDoor.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
            }
        } 
    }
     
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            playerIsHere = true;
            levelExitSensor.GetComponent<CloseSesame>().enabled = false;
        }
    }
     
    private void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            playerIsHere = false;
            levelExitSensor.GetComponent<CloseSesame>().enabled = true;
        }
    }
}
