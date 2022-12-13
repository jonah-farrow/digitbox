using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public string levelID;
    private string levelEntrance;
    private Camera cameraA;
    public Camera cameraB;
    public Material cameraMatB;
    public Material cameraMatA;
    // Start is called before the first frame update
    void Start()
    {
        levelEntrance = levelID + "_Entrance(Clone)";
        if(cameraB.targetTexture != null){
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;  
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
                Debug.Log("ShitBroke");
                Debug.Log(GameObject.Find(lvlEntranceCamera).GetComponent<Camera>());
            }
        }
    }
}
