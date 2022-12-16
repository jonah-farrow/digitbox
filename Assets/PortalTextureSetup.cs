using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code was helped by this tutorial https://www.youtube.com/watch?v=-sNbIGMqbhs

public class PortalTextureSetup : MonoBehaviour
{
    public string levelID;
    private string levelEntrance;
    private Camera cameraA; // camera B
    public Camera cameraB; // camera B
    public Material cameraMatB; // camera material that B sees
    public Material cameraMatA; // camera material that A sees
    // Start is called before the first frame update

    // When the game begins we want to set the camera view of the render plane to be the same size as our monitor or else it will look weird.
    void Start()
    {
        levelEntrance = levelID + "_Entrance(Clone)";
        if(cameraB.targetTexture != null){ // if it has a render texture
            cameraB.targetTexture.Release(); // remove texture
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24); // set new target texture to be screen resolution
        cameraMatB.mainTexture = cameraB.targetTexture;  // set targetTexture as the main texture
    }

    void Update() {
        if(cameraA == null){
            string lvlEntranceCamera = levelEntrance + "/Camera_A";
            try{
                cameraA = GameObject.Find(lvlEntranceCamera).GetComponent<Camera>();
                if(cameraA.targetTexture != null){
                    cameraA.targetTexture.Release();
                }
                cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
                cameraMatA.mainTexture = cameraA.targetTexture;
            } catch {
                Debug.Log(GameObject.Find(lvlEntranceCamera).GetComponent<Camera>());
            }
        }
    }
}
