using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code was helped by this tutorial https://www.youtube.com/watch?v=-sNbIGMqbhs

public class PortalCamera : MonoBehaviour
{
    private Transform playerCamera; // players camera
    private Transform portal; // portal to transfer to
    private Transform otherPortal; // portal currently closest to player
    public bool isEntrance; // entrance to level
    public string levelName; // name of the level

    void Start() {
        try{
            playerCamera = GameObject.Find("FirstPerson-AIO Variant").transform.GetChild(0).GetChild(0).transform; // directly target our AIO
            otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(1).transform : GameObject.Find(levelName).transform.GetChild(2).transform; // directly target the otherPortal
            portal = isEntrance ? transform.root.GetChild(1) : transform.root.GetChild(2); // directly target the closest protal
        } catch {}
    }

    // Update is called once per frame
    void Update()
    {
        // because we are proceduralyl generating the levels we need code that handles different versions of the level
        if(otherPortal == null) // if the other portal is not set when the level is spawned
        {
            otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(1).transform : GameObject.Find(levelName).transform.GetChild(2).transform; // set the portal directly
        }
        if(portal == null) // if the closest portal is not set when the level is spawned
        {
            portal = isEntrance ? transform.root.GetChild(2) : transform.root.GetChild(1); // set the portal directly
        }
        
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position; // enables camera movement with player (creates perspective by moving the camera in sync with player)
        transform.position = portal.position + playerOffsetFromPortal; // enables camera movement with player (creates perspective by moving the camera in sync with player)

        // Angular difference in rotation
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation); // allow the other camera to rotate with the player (camera looks around inside portal)

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up); // allow the other camera to rotate with the player (camera looks around inside portal)
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward; // allow the other camera to rotate with the player (camera looks around inside portal)

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up); // makes the camera look in the right direction 
    }
}