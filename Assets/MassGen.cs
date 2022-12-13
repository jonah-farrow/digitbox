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
    public int objectQuantity;
    public int randomYPos;
    public int levelsToGenerate;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects(){
        levelsToGenerate = 0;
        while(objectQuantity < 20){
            randomYPos = Random.Range(0,360);
            
            if(levelsToGenerate < 1)
            {
                xPos = Random.Range(-77,77);
                zPos = Random.Range(-77, 77);
                yPos = Random.Range(10, 500);

                Instantiate(theLevel, new Vector3(xPos,yPos,zPos), transform.rotation); // change transform rotate to be use randomYPos on y-axis so each faces different way
            }

            xPos = Random.Range(-77,77);
            zPos = Random.Range(-77, 77);
            yPos = Random.Range(10, 500);

            Instantiate(theCube, new Vector3(xPos,yPos,zPos), transform.rotation);

            yield return new WaitForSeconds(0.1f); // perhaps increase this if we have a UI 3,2,1 start at the beginning of game
            levelsToGenerate +=1;
            objectQuantity += 1;
        }
    }

}
