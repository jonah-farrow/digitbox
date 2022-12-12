using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    
    //public GameObject theCube;
    public GameObject theLevel;
    public GameObject theCube;
    public int xPos;
    public int zPos;
    public int yPos;
    public int objectToGenerate;
    public int objectQuantity;
    public int randomYPos;
    public int levelsToGenerate;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects(){
        levelsToGenerate = 5;
        while(objectQuantity < 20 && levelsToGenerate < 5){
            randomYPos = Random.Range(0,360);
            xPos = Random.Range(-77,77);
            zPos = Random.Range(-77, 77);
            yPos = Random.Range(10,200);
           
            Instantiate(theCube, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            Instantiate(theLevel, new Vector3(xPos,yPos,zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);
            levelsToGenerate +=1;
            objectQuantity += 1;
        }
    }

}
