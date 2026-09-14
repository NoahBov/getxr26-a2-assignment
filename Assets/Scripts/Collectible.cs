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
    [SerializeField] private int scoreValue = 10;

    void OnTriggerEnter(Collider other)
    {
        // TODO: check whether `other` belongs to the Player
        // (e.g. other.CompareTag("Player")).

        // TODO: apply your game-state change here using `scoreValue` - a static
        // field, a simple manager script, whatever you like. No UI/HUD is required
        // yet: a Debug.Log line or a value you can watch change in the Inspector
        // is enough, as long as it's visible when you demo this.

        // TODO: destroy this GameObject. Remember: Destroy(gameObject) removes it
        // from the scene, but the Spawner's `spawnedObjects` list still holds a
        // (now-null) reference until the Spawner cleans it up too.
    }

    // TODO (out-of-bounds cleanup): decide how this disappears if the Player never
    // touches it - a lifetime timer (Destroy(gameObject, seconds) in Start()), a
    // position check in Update(), or a boundary trigger volume are all valid.
}

// Physics reminder: OnTriggerEnter only fires if (1) both GameObjects have a
// Collider, (2) at least one Collider has "Is Trigger" checked, (3) at least one
// of the two GameObjects has a Rigidbody (tick "Is Kinematic" if it shouldn't be
// pushed around by physics), and (4) the method is written as
// OnTriggerEnter(Collider other).
