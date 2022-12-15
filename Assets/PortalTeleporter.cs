using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    private Transform player;
    private Transform receiver;
    private bool playerIsOverlapping = false;
    public bool isLevel;
    public string levelName;

    void Start() {
        //Finds the player in the scene
        player = GameObject.Find("FirstPerson-AIO Variant").transform;
        //Attempts to set the recieving plane, however due to the order of initialisation this may not always be possible
        //at the start, hence the repeated call in Update and the try catch. The ternary allows us to use one script to set the receiver 
        //plane despite whether we are entering or exiting a level.
        try{
            receiver = !isLevel ? GameObject.Find(levelName).transform.GetChild(1).GetChild(1) : 
                GameObject.Find(levelName).transform.GetChild(2).GetChild(1);
        } catch {}
    }

    // Update is called once per frame
    void Update()
    {
        //sets reciever if it was not able to previously.
        if(receiver == null){
            receiver = !isLevel ? GameObject.Find(levelName).transform.GetChild(1).GetChild(1) : GameObject.Find(levelName).transform.GetChild(2).GetChild(1);
        }
    }

    void LateUpdate()
    {
        //If the player is overlapping with the teleporting plane, then the player is teleported to the other portal.
        if(playerIsOverlapping){
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log("DOG PRODUCT: " + dotProduct);
            if(dotProduct < 0f){

                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180; // might not need this line
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;
                Debug.Log("POSITION OFFSET: " + positionOffset + " RECEIVER POSITION: " + receiver.position);
                playerIsOverlapping = false;
            }
       }     
    }

    //When the player collides with the teleporter the boolean is set to true so we know to teleport the player.
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            playerIsOverlapping = true;
            Debug.Log("COLLIDING WITH TELEPORTER");
        }
    }

    //Sets the boolean to false so the player isn't constantly pinged back to the receiver constantly.
    void OnTriggerExit (Collider other){
        if(other.tag == "Player"){
            playerIsOverlapping = false;
            Debug.Log("NOT TELEPORTING");
        }
    }
}