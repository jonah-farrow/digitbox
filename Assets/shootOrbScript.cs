using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootOrbScript : MonoBehaviour
{
    [SerializeField] GameObject teleOrbPrefab;
    [SerializeField] float orbForce = 15f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource audioSource;
    List<GameObject> orbsInFlight = new List<GameObject>();
    GameObject orbInFlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootOrb()
    {
        audioSource.PlayOneShot(shootSound, 0.5f);
        orbInFlight = Instantiate(teleOrbPrefab, transform.position, Quaternion.identity);
        orbsInFlight.Add(orbInFlight);
        orbInFlight.GetComponent<Rigidbody>().AddForce(transform.forward * orbForce, ForceMode.Impulse);
    }
}
