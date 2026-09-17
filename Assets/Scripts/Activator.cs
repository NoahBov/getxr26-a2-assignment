using UnityEngine;
using TMPro;

public class Activator : MonoBehaviour
{
    public bool spawnerActive = false;
    public int points;
    public TextMeshProUGUI pointsText;
    [SerializeField] GameObject collectible;

    private void Start()
    {
        points = 0;
        SetPointsText();
        
    }

    private void Update()
    {
        if (collectible.GetComponent<Collectible>().coinCollected)
        {
            points += collectible.GetComponent<Collectible>().scoreValue;
            SetPointsText();
            collectible.GetComponent<Collectible>().coinCollected = false;
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
        Debug.Log("Points collected: " + points);
        //SetPointsText();
    }

}
