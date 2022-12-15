using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalGun : MonoBehaviour
{
    [SerializeField] private Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //Detection is a little buggy for some reason, need to look into why the raycast isn't 100% working
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(muzzle.position, muzzle.forward*100);
        if(Input.GetMouseButtonDown(0))
        {
            muzzle.gameObject.GetComponent<shootOrbScript>().shootOrb();
            // if(Physics.Raycast(muzzle.position, muzzle.transform.forward, out RaycastHit hitInfo, 10000))
            // {
            //     //transform.root.position = hitInfo.point;
                
            // }
        }
    }
}
