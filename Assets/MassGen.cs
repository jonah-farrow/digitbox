using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    public GameObject theLevel;
    public GameObject theCube;
    public GameObject theScifiBox;
    public GameObject theComputer;
    public GameObject theConnectedComputer;
    public GameObject theBarrel;
    public int xPos;
    public int zPos;
    public int yPos;
    public int objectQuantity;
    public int randomYPos;
    public bool isLevelGenerated;
    public int randObjGen;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects(){
       
        isLevelGenerated = false;
        while(objectQuantity < 20){
            randObjGen = Random.Range(0,5); // Does not include level as we require a guranteed spawn of one
            randomYPos = Random.Range(0,360);
            
            if(!isLevelGenerated)
            {
                xPos = Random.Range(-77,77);
                zPos = Random.Range(-77, 77);
                yPos = Random.Range(10, 500);

                Instantiate(theLevel, new Vector3(xPos,yPos,zPos), transform.rotation); // change transform rotate to be use randomYPos on y-axis so each faces different way
                isLevelGenerated = true;
            }

            xPos = Random.Range(-87,87);
            zPos = Random.Range(-87, 87);
            yPos = Random.Range(10, 500);

            switch (randObjGen){
                case 0:
                    Instantiate(theCube, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 1:
                    Instantiate(theScifiBox, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 2:
                    Instantiate(theComputer, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 3:
                    Instantiate(theConnectedComputer, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 4:
                    Instantiate(theBarrel, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;
            }

            yield return new WaitForSeconds(0.1f); // perhaps increase this if we have a UI 3,2,1 start at the beginning of game
            
            objectQuantity += 1;
        }
    }

}
