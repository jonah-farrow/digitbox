using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private Transform playerCamera;
    private Transform portal;
    private Transform otherPortal;
    public bool isEntrance;
    public string levelName;

    void Start() {
        playerCamera = GameObject.Find("FirstPerson-AIO").transform.GetChild(0).GetChild(0).transform;
        otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(4).transform : GameObject.Find(levelName).transform.GetChild(1).transform;
        portal = transform.root.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(otherPortal == null)
        {
            otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(4).transform : GameObject.Find(levelName).transform.GetChild(1).transform;
        }
        
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        // Angular difference in rotation
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
