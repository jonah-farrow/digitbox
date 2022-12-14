using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrajectoryTracer : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene physicsScene;
    [SerializeField] private LineRenderer trajectoryLine;
    [SerializeField] private int maxSegments = 100;
    [SerializeField] Transform floor;


    void Start(){
        CreatePhysicsScene();
    }
    
    void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        var ghostObj = Instantiate(floor.gameObject, floor.position,floor.rotation);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);

    }

    // Update is called once per frame
    public void SimulateTrajectory(TeleOrb teleOrbPrefab, Vector3 positionInit)
    {
        var ghostObj = Instantiate(teleOrbPrefab, positionInit, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, simulationScene);

        ghostObj.Init(15f, transform.forward);
    
        trajectoryLine.positionCount = maxSegments;

        for (int i = 0; i < maxSegments; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            trajectoryLine.SetPosition(i,ghostObj.transform.position);
        }

        Destroy(ghostObj.gameObject);
    }
}
