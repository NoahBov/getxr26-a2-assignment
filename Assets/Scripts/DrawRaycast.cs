using UnityEngine;
using UnityEngine.InputSystem;  // before class declaration! 

public class DrawRaycast : MonoBehaviour
{
    [SerializeField] InputActionReference moveAction;

    public Camera viewCamera;
    float interactRange = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = viewCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red);
    }
}
