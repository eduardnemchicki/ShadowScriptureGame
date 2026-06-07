using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [AI OVERVIEW] UNUSED free-fly camera: WASD move on Horizontal/Vertical, mouse look on Mouse X/Y. Not referenced by GameEvents or puzzle flow; level camera handled by RoundVictoryScript and scene setup instead.
public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.forward * moveForward + transform.right * moveRight;
        transform.position += move;
    }

    void HandleRotation()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float rotateVertical = -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.Rotate(0, rotateHorizontal, 0, Space.World);
        transform.Rotate(rotateVertical, 0, 0, Space.Self);
    }
}
