using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootOrbScript : MonoBehaviour
{
    //orb prefab to be used to teleport.
    [SerializeField] TeleOrb teleOrbPrefab;
    [SerializeField] TeleOrb teleOrbGhostPrefab;
    //force that the orb should be thrown at
    [SerializeField] float orbForce = 30f;
    //Sounds
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource audioSource;
    //Line renderer used to render the aim trajectory of the teleOrbs
    [SerializeField] private LineRenderer aimLineRenderer;
    //Number of segments to be used when rendering the trajectory, more segements = higher defintion line
    private int lineSegments = 100;
    private float timeBetweenPoints = 0.1f;
    //List of points to be used by the arc equation and line renderer to create the arc.
    private List<Vector3> lineSegmentPoints = new List<Vector3>();
    //Current orb in flight
    TeleOrb orbInFlight;
    //LayerMask that we can teleport to
    public LayerMask teleportable;

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
            //Slow down time
            Time.timeScale = 0.5f;
            //Initialise the line renderer to have the desired amount of empty line segments
            aimLineRenderer.positionCount = (int)lineSegments;
            //initialise the segments list to be empty once aagin.
            lineSegmentPoints = new List<Vector3>();
            ArcPrediction();
        }  else {
            //reset the line renderer, essentially makes it invisible
            aimLineRenderer.positionCount = 0;
            //Set time scale back to normal
            Time.timeScale = 1.0f;
        }

        //if Left click, then shoot
        if(Input.GetMouseButtonDown(0))
        {
            shootOrb();
        }
    }

    public void shootOrb()
    {
        //plays shoot sound
        audioSource.PlayOneShot(shootSound, 0.5f);
        //Creates a new TeleOrb at the muzzle point
        orbInFlight = Instantiate(teleOrbPrefab, transform.position, Quaternion.identity);
        //runs the init method of the orb, which gives it it's initial force.
        orbInFlight.GetComponent<TeleOrb>().Init(orbForce, transform.forward);
    }

    //enumerator made to wait for a set time.
    IEnumerator UpdateAimTraceTimer()
    {
        yield return new WaitForSeconds(0.1f);
    }

    //Maths and code inspiration taken from https://www.youtube.com/watch?v=RnEO3MRPr5Y
    //creates a list of points that the object is planned to travel along in an arc, starting at the muzzle point.
    void ArcPrediction() {
        Vector3 initPos = transform.position;
        Vector3 initVelocity = transform.forward * orbForce;
        for (float t = 0; t < lineSegments; t += timeBetweenPoints)
        {
            //Handles x and z coordinates as with flight paths for objects, the horizontal movement stays the smae no matter what
            Vector3 pointToAdd = initPos + t * initVelocity;
            //yVelocity = initYPos + (initYVel*timeStep) - 1/2((gravity*timeStep) ^ 2)
            //calculates the new y position of the next point in the arc using the above formula.
            pointToAdd.y = initPos.y + initVelocity.y * t + ((0.5f*(Physics.gravity.y)*(t*t)));
            //adds the new point to the list of points to be rendered by the lineRenderer.
            lineSegmentPoints.Add(pointToAdd);

            //Checks to see if the line has collided with an object with an appropriate layerMask that we determine, 
            //So we don't over render the line.
            if(Physics.OverlapSphere(pointToAdd, 0.5f, teleportable).Length > 0)
            {
                aimLineRenderer.positionCount = lineSegmentPoints.Count;
                break;
            }
        }
        //Renders the arc
        aimLineRenderer.SetPositions(lineSegmentPoints.ToArray());
    }
}
