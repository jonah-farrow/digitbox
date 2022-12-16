using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpin : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float zPos;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xPos, yPos, zPos); // simply rotate the object using the values provided
    }
}
