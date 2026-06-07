using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// [AI OVERVIEW] Moves this Transform between origin and targetPlace when GameEvents.paperToggle fires (e.g. paper/instrument raised or lowered). Uses ObjectMoveScriptsBase3D.MoveToTarget; pairs with ControlsUsage and candle/paper gameplay flow.
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
            StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(targetPlace.position, targetPlace.localRotation, this.transform, timeToMove));
        }
        else
        {
            StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(originPlace, originRotation,this.transform,timeToMove));
        }
    }
    
}


