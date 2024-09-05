using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundVictoryScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Animator doorAnimation;
    [SerializeField] private float timeToMove;
    private void ExitLevel()
    {
        doorAnimation.enabled = true;
        StartCoroutine(ObjectMoveScript.MoveToTarget(target.position, target.rotation, mainCamera.transform, timeToMove));
    }

}
