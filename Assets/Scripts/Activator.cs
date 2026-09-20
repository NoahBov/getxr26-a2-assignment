using UnityEngine;
using TMPro;

public class Activator : MonoBehaviour
{
    public bool spawnerActive;
    [SerializeField] int points;
    private bool coinCollected;

    private void Start()
    {
        spawnerActive = false;
        coinCollected = false;
        points = 0;

        Debug.Log("Activation " + points);


    }

    private void Update()
    {
        Debug.Log("Points " + points);

        if (coinCollected)
        {

            Debug.Log("Points collected: " + points);
            coinCollected = false;
        }
    }

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
        points += 10;
        Debug.Log("PointsTracker: " + points);
   
        coinCollected = true;
    }

}
