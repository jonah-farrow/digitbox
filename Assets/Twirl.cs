using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twirl : MonoBehaviour
{
    public int typeOfTwirl;
    public float xPos;
    public float yPos;
    public float zPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(-0.1f, 0.1f);
        yPos = Random.Range(-0.1f, 0.1f);
        zPos = Random.Range(-0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xPos, yPos, zPos);
    }
}
