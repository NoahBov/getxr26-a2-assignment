using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool spawnerActive = false;
    public int points = 0;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player detected");
            if (spawnerActive) { spawnerActive = false;
                Debug.Log("spawner deactivated: " + !spawnerActive);
            }
            else { spawnerActive = true;
                Debug.Log("spawner activated: " + spawnerActive);
            }
        }
    }

    public void PointsTracker()
    {
        Debug.Log("Points collected: " + points);
    }

}
