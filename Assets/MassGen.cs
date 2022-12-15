using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGen : MonoBehaviour
{
    public GameObject theLevel;
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
        while(objectQuantity < 50){
            randObjGen = Random.Range(0,5); // Does not include level as we require a guranteed spawn of one
            randomYPos = Random.Range(0,360);
            
            if(!isLevelGenerated)
            {
                xPos = Random.Range(-50,50);
                zPos = Random.Range(-50, 50);
                yPos = Random.Range(300, 500);

                Instantiate(theLevel, new Vector3(xPos,yPos,zPos), transform.rotation); // change transform rotate to be use randomYPos on y-axis so each faces different way
                isLevelGenerated = true;
            }

            xPos = Random.Range(-80,80);
            zPos = Random.Range(-80, 80);
            yPos = Random.Range(20, 500);

            switch (randObjGen){
                case 0:
                    Instantiate(theScifiBox, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 1:
                    Instantiate(theComputer, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 2:
                    Instantiate(theConnectedComputer, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;

                case 3:
                    Instantiate(theBarrel, new Vector3(xPos,yPos,zPos), transform.rotation);
                break;
            }

            yield return new WaitForSeconds(0.1f); // perhaps increase this if we have a UI 3,2,1 start at the beginning of game
            
            objectQuantity += 1;
        }
    }

}
