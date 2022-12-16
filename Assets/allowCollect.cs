using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Collectable"){ // if player collide with collectable
            collectableCollector collector = other.gameObject.GetComponent<collectableCollector>(); // grab collectable component

            collector.onPickup(); // run onPickup() to disable the collectable and play a noise
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
