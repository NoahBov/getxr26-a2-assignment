using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// GETXR 2026 - Assignment 1: Basic Movement.
/// Use on the 'Player' GameObject. Complete the TODOs so the object strafes
/// smoothly on two world-space axes based on keyboard input — no rotation.
/// Use Keyboard.current, not the deprecated Input.GetAxis.
/// </summary>

public class Mover : MonoBehaviour
{
    [Header("Movement Settings")]
    // TODO: expose this field in the Inspector
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float runSpeed = 10.0f;
    private float moveSpeed;
    // TODO: add your own field for a running speed — a direct,
    // Inspector-exposed value, used below while Shift
    // is held.

    void Start()
    {
        Debug.Log($"[Mover] Initialized on {gameObject.name}. MoveSpeed is set to {moveSpeed}.");
    }

    void Update()
    {
        // TODO: read A/D and W/S via Keyboard.current as -1/0/+1 each.
        float inputX = 0f;
        if (Keyboard.current.dKey.isPressed) inputX += 1f;
        if (Keyboard.current.aKey.isPressed) inputX -= 1f;

        float inputZ = 0f;
        if (Keyboard.current.wKey.isPressed) inputZ += 1f;
        if (Keyboard.current.sKey.isPressed) inputZ -= 1f;

        // TODO: combine into a Vector3 (X, 0, Z), normalized if diagonal.
        Vector3 movement = new Vector3(inputX, 0, inputZ).normalized;

        // Straight strafe: A/D = left/right, W/S = forward/back. Don't rotate
        // the object to turn — that's a tank-control scheme, not a strafe.



        // TODO: pick moveSpeed or your new running-speed field depending on whether Keyboard.current.leftShiftKey is held.
        if (Keyboard.current.shiftKey.isPressed)
        {
            moveSpeed = runSpeed;
        }
        else { moveSpeed = walkSpeed;}



        // TODO: apply Time.deltaTime and transform.Translate to move the object.

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
