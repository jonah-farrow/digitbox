using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSetup : MonoBehaviour
{
    public Camera camA;
    public Camera camB;
    public Material portalEntry01;
    public Material portalEntry02;
    // Start is called before the first frame update
    void Start()
    {
        if(camA.targetTexture != null){
            camA.targetTexture.Release();
        }
        camA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        portalEntry01.mainTexture = camA.targetTexture;

        // replicate above code for portal exit to colleseum
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
