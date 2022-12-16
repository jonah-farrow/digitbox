using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_MassGen : MonoBehaviour
{
    public GameObject theCollectable; // the gem asset
    public GameObject theCube; // the cube asset
    public int xPos; // position object will instantiate along the x-axis
    public int xMin; // min bound where object can spawn along x-axis
    public int xMax; // max bound where object can spawn along x-axis
    public int zPos; // position object will instantiate along the z-axis
    public int zMin; // min bound where object can spawn along z-axis
    public int zMax; // max bound where object can spawn along z-axis
    public int yPos; // position object will instantiate along the y-axis
    public int yMin; // min bound where object can spawn along y-axis
    public int yMax; // max bound where object can spawn along y-axis
    public int objectQuantity; // number of objects generated
    public bool isCollectableGenerated; // is collectable generated

    void Start()
    {
        StartCoroutine(GenerateObjects()); // begin coroutine of spawning objects
    }

    IEnumerator GenerateObjects(){
       
        isCollectableGenerated = false; // collectable has not been spawned at the start
        while(objectQuantity < 5){ // spawn 50 objects
            if(!isCollectableGenerated){ // spawn collectable if not spawned already
                xPos = Random.Range(xMin, xMax); // generate random x value
                zPos = Random.Range(zMin, zMax); // generate random z value
                yPos = Random.Range(yMin, yMax); // generate random y value

                Instantiate(theCollectable, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate collectable using random coordinates as vector and prefab current rotation
                isCollectableGenerated = true; // stop generating collectables
            }

                xPos = Random.Range(xMin, xMax); // generate random x value
                zPos = Random.Range(zMin, zMax); // generate random z value
                yPos = Random.Range(yMin, yMax); // generate random y value
            
            Instantiate(theCube, new Vector3(xPos,yPos,zPos), transform.rotation); // instantiate tehCube using random coordinates as vector and prefab current rotation

            yield return new WaitForSeconds(0.1f); // yields spawn rate so that player has the chance to see the levels spawn in (adds to effect of game)
            objectQuantity += 1; // increase number of objects currently spawned by 1
        }

        

        }
    }
