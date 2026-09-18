using UnityEngine;
using TMPro;

public class Activator : MonoBehaviour
{
    public bool spawnerActive;
    public int points;
    public TextMeshProUGUI pointsText;
    [SerializeField] GameObject collectible;
    private bool coinCollected;

    private void Start()
    {
        spawnerActive = false;
        coinCollected = false;
        points = 0;
        SetPointsText();
        
    }

    private void Update()
    {
        if (coinCollected)
        {
            SetPointsText();
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


    public void SetPointsText()
    {
        pointsText.text = "Points collected: " + points.ToString();
        Debug.Log("text renewed");
    }

    public void PointsTracker()
    {
        points += collectible.GetComponent<Collectible>().scoreValue;
        Debug.Log("Points collected: " + points);
        SetPointsText();
        coinCollected = true;
    }

}
