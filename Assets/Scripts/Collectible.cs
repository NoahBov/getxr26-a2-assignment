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
    [SerializeField] GameObject activator;

    private void Start()
    {
        Destroy(this.gameObject, 60);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //activator.GetComponent<Activator>().points += scoreValue;
            activator.GetComponent<Activator>().PointsTracker();
            Destroy(this.gameObject);
        }
    }
}

