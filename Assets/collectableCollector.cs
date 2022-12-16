using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCollector : MonoBehaviour
{
    public AudioClip collectSound; // sound to play when collected the collectable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onPickup(){
        gameObject.SetActive(false); // disable the object in the scene
        AudioSource.PlayClipAtPoint(collectSound, transform.position); // play audio clip 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 1.0f, 0.0f); // simply rotate the collectable 
    }
}
