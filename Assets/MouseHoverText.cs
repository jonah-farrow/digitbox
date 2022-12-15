using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseEnter() {
        Debug.Log("Hovering");
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
