using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(float orbForce, Vector3 forward)
    {
        GetComponent<Rigidbody>().AddForce(forward * orbForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
