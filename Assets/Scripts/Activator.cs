using UnityEngine;
using TMPro;

public class Activator : MonoBehaviour
{
    public bool spawnerActive; //for spawner to start and stop spawning
    public int points;  //to keep track of points collected from collectibles

    private void Start()
    {
        spawnerActive = false; //spawner does not spawn until player triggers activator
        points = 0;
    }

    
    //Checks if player has triggered the activator, triggering switches spawnerActive state, which the spawner uses 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (spawnerActive) { spawnerActive = false;
                Debug.Log("spawner deactivated: " + !spawnerActive);
            }
            else { spawnerActive = true;
                Debug.Log("spawner activated: " + spawnerActive);
            }
        }
    }


  //Gets called by collectible when player collects
    public void PointsTracker()
    {
        Debug.Log("Points collected: " + points);
    }

}
