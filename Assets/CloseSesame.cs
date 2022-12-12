using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSesame : MonoBehaviour
{
    [SerializeField] private GameObject movingDoor;
    [SerializeField] private GameObject levelEntranceSensor;
    private float maximumOpening = 10f;
    private float maximumClosing = 0f;
     
    private float movementSpeed = 5f;
     
    private bool playerIsHere2 = false;
     
    // Start is called before the first frame update
    void Start()
    {
        //playerIsHere2 = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(playerIsHere2){
            if(movingDoor.transform.localPosition.y < maximumOpening){           
                movingDoor.transform.Translate(0f, movementSpeed * Time.deltaTime, 0f);
            }
        }else{
            if(movingDoor.transform.localPosition.y > maximumClosing){
                movingDoor.transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
            }
        } 
    }
     
    private void OnTriggerEnter(Collider col2){
        if(col2.gameObject.tag == "Player"){
            playerIsHere2 = true;
            levelEntranceSensor.GetComponent<OpenSesame>().enabled = false;
        }
    }
     
    private void OnTriggerExit(Collider col2){
        if(col2.gameObject.tag == "Player"){
            playerIsHere2 = false;
            levelEntranceSensor.GetComponent<OpenSesame>().enabled = true;
        }
    }
}
