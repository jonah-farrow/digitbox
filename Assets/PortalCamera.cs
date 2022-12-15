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
        try{
            playerCamera = GameObject.Find("FirstPerson-AIO Variant").transform.GetChild(0).GetChild(0).transform;
            otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(1).transform : GameObject.Find(levelName).transform.GetChild(2).transform;
            portal = isEntrance ? transform.root.GetChild(1) : transform.root.GetChild(2);
        } catch {}
    }

    // Update is called once per frame
    void Update()
    {
        if(otherPortal == null)
        {
            otherPortal = isEntrance ? GameObject.Find(levelName).transform.GetChild(1).transform : GameObject.Find(levelName).transform.GetChild(2).transform;
        }
        if(portal == null)
        {
            portal = isEntrance ? transform.root.GetChild(2) : transform.root.GetChild(1);
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
