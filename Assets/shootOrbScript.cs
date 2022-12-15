using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootOrbScript : MonoBehaviour
{
    //LineRenderer class to show the arc of the ball
    [SerializeField] private TrajectoryTracer tracer;
    //orb prefab to be used to teleport.
    [SerializeField] TeleOrb teleOrbPrefab;
    //force that the orb should be thrown at
    [SerializeField] float orbForce = 15f;
    //Sounds
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource audioSource;
    //Line renderer used to render the aim trajectory of the teleOrbs
    [SerializeField] private LineRenderer aimLineRenderer;
    //Number of segments to be used when rendering the trajectory, more segements = higher defintion line
    private int lineSegments = 25;
    //List of points to be used by the arc equation and line renderer to create the arc.
    private List<Vector3> lineSegmentPoints = new List<Vector3>();
    //Not sure if I'll need this, but this is a list of orbs in flight, incase I need to decide the order that they are executed.
    List<TeleOrb> orbsInFlight = new List<TeleOrb>();
    //Current orb in flight
    TeleOrb orbInFlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check to see if the player is holding right click, aka aiming
        if(Input.GetKey("mouse 1"))
        {
            UpdateAimTrace();
            tracer.SimulateTrajectory(teleOrbPrefab, transform.position);
        }
    }

    public void shootOrb()
    {
        audioSource.PlayOneShot(shootSound, 0.5f);
        orbInFlight = Instantiate(teleOrbPrefab, transform.position, Quaternion.identity);
        orbsInFlight.Add(orbInFlight);
        orbInFlight.GetComponent<TeleOrb>().Init(orbForce, transform.forward);
    }

    public void UpdateAimTrace()
    {

    }
}
