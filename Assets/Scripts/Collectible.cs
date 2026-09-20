using System;
using UnityEngine;

/// <summary>
/// GETXR 2026 - Assignment 2: Gameplay and Spawners
/// Attach this to the prefab your Spawner instantiates. Handles what happens when
/// the Player touches it, and how it disappears if the Player never does.
/// </summary>
public class Collectible : MonoBehaviour
{
    [Header("Collision Settings")]
    [Tooltip("Whatever this is worth toward your game state - score, health, etc.")]
    [SerializeField] public int scoreValue = 10;
    
    GameObject activatorObj;
    Activator activator;

    void Start()
    {
        //collectible finds the one and only activator :,) and gets the activator script
        activatorObj = GameObject.FindWithTag("Activator");
        activator = activatorObj.GetComponent<Activator>();

        //after 60s, destroy this collectible
        Destroy(this.gameObject, 60);
    }


    //Destroys collectible if it falls
    private void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //check if player triggers the collectible
        if (other.gameObject.CompareTag("Player"))
        {
            activator.points += scoreValue; //add value of this collectible to points tracked by activator
            activator.PointsTracker();  //make activator write the current number of points
            Destroy(this.gameObject);   //✨disappear✨
        }
    }
}

