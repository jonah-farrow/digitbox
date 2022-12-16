using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    public GameObject theLevel; // first level
    public GameObject theLevel2; // second level
    public GameObject theLevel3; // third level
    public GameObject theScifiBox; // box asset
    public GameObject theComputer; // computer asset
    public GameObject theConnectedComputer; // big computer asset
    public GameObject theBarrel; // barrel asset
    public int xPos; // position object will instantiate along the x-axis
    public int zPos; // position object will instantiate along the z-axis
    public int yPos; // position object will instantiate along the y-axis
    public int objectQuantity; // number of objects generated
    public bool isLevelGenerated; // is the first level generated
    public bool isLevel2Generated; // is the second level generated
    public bool isLevel3Generated; // is the third level generated
    public int randObjGen; // which random asset (not level) to generate

    void Start()
    {
        StartCoroutine(GenerateObjects()); // begin coroutine of spawning objects
    }

    IEnumerator GenerateObjects(){
       
        isLevelGenerated = false; // level has not been spawned at the start
        while(objectQuantity < 50){ // spawn 50 objects
            randObjGen = Random.Range(0,5); // Does not include level as we require a guranteed spawn of one

            
            if(!isLevelGenerated) // spawn level 1 if not spawned already
            {
                xPos = Random.Range(-50,50); // generate random x value
                zPos = Random.Range(-50, 50); // generate random z value
                yPos = Random.Range(200, 300); // generate random y value

                Instantiate(theLevel, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate level 1 using random coordinates as vector and prefab current rotation
                isLevelGenerated = true; // level is generated (dont generate again)
            }

            if(!isLevel2Generated) // spawn level 2 if not spawned already
            {
                xPos = Random.Range(-50,50); // generate random x value
                zPos = Random.Range(-50, 50); // generate random y value
                yPos = Random.Range(310, 400); // generate random z value

                Instantiate(theLevel2, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate level 2 using random coordinates as vector and prefab current rotation
                isLevel2Generated = true; // level is generated (dont generate again)
            }

            if(!isLevel3Generated) // spawn level 3 if not spawned already
            {
                xPos = Random.Range(-50,50); // generate random x value
                zPos = Random.Range(-50, 50); // generate random y value
                yPos = Random.Range(410, 500); // generate random z value

                Instantiate(theLevel3, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate level 3 using random coordinates as vector and prefab current rotation
                isLevel3Generated = true; // level is generated (dont generate again)
            }

            xPos = Random.Range(-80,80); // generate random x value
            zPos = Random.Range(-80, 80); // generate random y value
            yPos = Random.Range(20, 500); // generate random z value

            switch (randObjGen){ // switch to decide which random object to spawn
                case 0:
                    Instantiate(theScifiBox, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate theScifiBox using random coordinates as vector and prefab current rotation
                break;

                case 1:
                    Instantiate(theComputer, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate theComputer using random coordinates as vector and prefab current rotation
                break;

                case 2:
                    Instantiate(theConnectedComputer, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate theConnectedComputer using random coordinates as vector and prefab current rotation
                break;

                case 3:
                    Instantiate(theBarrel, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate theBarrel using random coordinates as vector and prefab current rotation
                break;
            }

            yield return new WaitForSeconds(0.1f); // yields spawn rate so that player has the chance to see the levels spawn in (adds to effect of game)
            
            objectQuantity += 1; // increase number of objects currently spawned by 1
        }
    }

}
