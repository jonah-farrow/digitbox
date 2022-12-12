using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    
    public GameObject theCube;
    public GameObject theLevel;
    public int xPos;
    public int zPos;
    public int yPos;
    public int objectToGenerate;
    public int objectQuantity;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects(){
        while(objectQuantity < 50){
            objectToGenerate = Random.Range(1,3);
            xPos = Random.Range(-88,87);
            zPos = Random.Range(-88, 89);
            yPos = Random.Range(0,200);
            if(objectToGenerate == 1){
                Instantiate(theCube, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            }
            if(objectToGenerate == 2){
                Instantiate(theLevel, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
            objectQuantity += 1;
        }
    }

}
