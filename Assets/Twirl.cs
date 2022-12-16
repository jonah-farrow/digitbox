using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twirl : MonoBehaviour
{
    public float xPos; // value to rotate around x axis
    public float yPos; // value to rotate around y axis


    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(-0.01f, 0.01f);
        yPos = Random.Range(-0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xPos, yPos, 0); // rotate object using randomly allocated x and y
    }
}
