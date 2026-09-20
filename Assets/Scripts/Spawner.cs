using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GETXR 2026 - Assignment 2: Gameplay and Spawners
/// Attach to a dedicated GameObject in the scene (the "Spawner" object is already
/// there for you) - not to the Player, and not to the thing you're spawning.
/// Complete the TODOs so it instantiates `prefabToSpawn` on a timed interval while
/// `isActive`, keeps track of every active instance in `spawnedObjects` up to
/// `maxActiveObjects`, and can be toggled on/off at runtime.
/// </summary>

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("The prefab this Spawner instantiates. Assign it in the Inspector.")]
    [SerializeField] private GameObject prefabToSpawn;

    [Tooltip("Seconds between spawns.")]
    [SerializeField] private float spawnInterval = 2.0f;

    [Header("Activation")]
    [Tooltip("Whether the Spawner is currently instantiating. Toggle this at runtime " +
             "(key press or trigger switch, your choice) to pause/resume spawning.")]
    [SerializeField] private bool isActive = true;

    [Header("Tracking")]
    [Tooltip("Every active instance this Spawner has created and not yet destroyed.")]
    [SerializeField] private List<GameObject> spawnedObjects = new List<GameObject>();

    [Tooltip("Hard cap on simultaneous active instances - stop spawning once this is reached.")]
    [SerializeField] private int maxActiveObjects = 10;

    private float timer = 0f;

    
    //for storing where collectible will be spawned
    private Vector3 spawnPoint;
    //the object that the player interacts with the start and stop the spawning of collectibles
    [SerializeField] Activator activator;
    //player, for checking range player-collectible
    [SerializeField] private GameObject player;


    void Update()
    {
        //activator object controlls boolean isActive
        isActive = activator.spawnerActive;

        //timer for checking spawnInterval
        if (isActive) { timer += Time.deltaTime; }

        //if spawning is active, enough time has passed, and the list is not full
        if (timer >= spawnInterval && spawnedObjects.Count < maxActiveObjects && isActive)
        {
            SpawnObject();  //spawns a new collectible
            timer = 0;      //reset timer
        }

        OutOfRange();   //checks the distance between collectible and player

        //occasionally check for null objects in list
        RemoveFromList();

    }

    void SpawnObject()
    {
        //get a random position within a circle with radius 5
        Vector2 randomRadius = Random.insideUnitCircle * 5;
        //set the point where collectible should spawn to a location within radius 5 of the spawner 
        spawnPoint = transform.position + new Vector3(randomRadius.x, 0, randomRadius.y);

        //create a new instance of the prefab at the spawnPoint, add it to the list of created objects
        GameObject newSpawn = Instantiate(
            prefabToSpawn, spawnPoint, Quaternion.Euler(0, Random.Range(-90, 90), 0)
            );
        spawnedObjects.Add(newSpawn);
    }


    //Goes through list of created objects, if object was destroyed, removes it from the list
    void RemoveFromList()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null) spawnedObjects.RemoveAt(i);
        }
    }


    //Goes through list of created objects
    //checks the distance between player and object if the object was not destroyed already
    //destroys the object if it is more than 10 away from the player
    void OutOfRange()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] != null) {

                float dist = Vector3.Distance(player.transform.position, spawnedObjects[i].transform.position);
                if (dist > 10)
                {
                    Destroy(spawnedObjects[i]);
                }
            }
        }
    }
}
