using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Gives the orb it's initial force and velocity once shot.
    public void Init(float orbForce, Vector3 forward)
    {
        GetComponent<Rigidbody>().AddForce(forward * orbForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if the orb has collided with the outside cylinder it doesn't teleport to avoid 'cheating'
        if(other.name != "Cylinder"){
            GameObject.Find("FirstPerson-AIO Variant").transform.position = transform.position;
        }
        Destroy(this.gameObject);
    }
}
