using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float maxX = 10f;
    public float minX = -10f;
    public float maxY = 10f;
    public float minY = -10f;

    bool shouldBeActive;
    private void Start()
    {
        shouldBeActive = true;
        GameEvents.paperToggle.AddListener((x) => shouldBeActive = !x);
        //GameEvents.paperToggle.AddListener(ActiveToggle);

    }
    void Update()
    {
        if (shouldBeActive)
        {
            HandleMovement();
        }
    }


    //private void ActiveToggle(bool newCondition)
    //{
    //    shouldBeActive = false;
    //    if (!newCondition)
    //    {
    //        GameEvents.instrumentFinishedMove.RemoveAllListeners();
    //        GameEvents.instrumentFinishedMove.AddListener(() => shouldBeActive = true);
    //    }
    //}
    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") *moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveHorizontal + transform.up * moveVertical ;

        move.x = Mathf.Clamp(transform.position.x + move.x, minX, maxX);
        move.y = Mathf.Clamp(transform.position.y + move.y, minY, maxY);
        move.z = transform.position.z;
        transform.position = move;
    }

}
