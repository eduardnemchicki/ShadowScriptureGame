using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMoveScript : MonoBehaviour
{
    private Vector3 originPlace;
    private Quaternion originRotation;
    public Transform targetPlace;
    public float timeToMove = 10f;

    private void Awake()
    {
        originPlace = this.transform.position;
        originRotation = this.transform.rotation;
        GameEvents.paperToggle.AddListener(PutUpOrDown);
    }
    private void PutUpOrDown(bool shouldPutDown)
    {
        if (shouldPutDown)
        {
            StartCoroutine(MoveToTarget(targetPlace.position, targetPlace.localRotation));
        }
        else
        {
            StartCoroutine(MoveToTarget(originPlace, originRotation));
        }
    }
    private IEnumerator MoveToTarget(Vector3 newPlace, Quaternion newRotation)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;
        while (elapsedTime < timeToMove)
        {
            var curTimeSlot = elapsedTime / timeToMove;
            transform.position = Vector3.Lerp(startingPosition, newPlace, curTimeSlot); //should make the movement fluid
            transform.rotation = Quaternion.Lerp(startingRotation, newRotation, curTimeSlot);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPlace; // making sure our piece ends up where it should (if fluid movement is a bit off)
        transform.rotation = newRotation;
        //GameEvents.instrumentFinishedMove.Invoke();
    }
    public static IEnumerator MoveToTarget(Vector3 newPlace, Quaternion newRotation, Transform objectToMove, float timeToMove)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = objectToMove.position;
        Quaternion startingRotation = objectToMove.rotation;
        while (elapsedTime < timeToMove)
        {
            var curTimeSlot = elapsedTime / timeToMove;
            objectToMove.position = Vector3.Lerp(startingPosition, newPlace, curTimeSlot); //should make the movement fluid
            objectToMove.rotation = Quaternion.Lerp(startingRotation, newRotation, curTimeSlot);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.position = newPlace; // making sure our piece ends up where it should (if fluid movement is a bit off)
        objectToMove.rotation = newRotation;
        //GameEvents.instrumentFinishedMove.Invoke();
    }
}


