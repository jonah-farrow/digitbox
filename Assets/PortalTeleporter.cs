using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    public bool isLevel;
    public string levelName;

    void Start() {
        player = GameObject.Find("FirstPerson-AIO").transform;
        receiver = !isLevel ? GameObject.Find(levelName).transform.GetChild(4).GetChild(1) : 
            GameObject.Find(levelName).transform.GetChild(2).GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(receiver == null){
            receiver = !isLevel ? GameObject.Find(levelName).transform.GetChild(4).GetChild(1) : GameObject.Find(levelName).transform.GetChild(2).GetChild(1);
            Debug.Log(transform.root);
            Debug.Log(isLevel);
            Debug.Log(GameObject.Find(levelName));
        }
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

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            playerIsOverlapping = true;
            Debug.Log("COLLIDING WITH TELEPORTER");
        }
    }

    void OnTriggerExit (Collider other){
        if(other.tag == "Player"){
            playerIsOverlapping = false;
            Debug.Log("NOT TELEPORTING");
        }
    }
}
