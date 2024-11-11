using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundVictoryScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform targetBeforeDoor;
    [SerializeField] private Transform targetAfterDoor;
    [SerializeField] private Animator doorAnimation;
    [SerializeField] private Image uiFadeOutImage;

    //timers
    [SerializeField] private float fadeDuration = 2f; // Duration of the fade
    [SerializeField] private float timeToMoveToDoor = 2f;// Time it takes to go to the door
    [SerializeField] private float timeToMoveOutTheDoor = 2f;// Time it takes to go out into the fadeout
    //timers
    private void Awake()
    {
        doorAnimation.enabled = false;
        GameEvents.levelComplete.AddListener(ExitLevel);
    }
    public void ExitLevel()
    {
        doorAnimation.enabled = true;
        StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(targetBeforeDoor.position, targetBeforeDoor.rotation, mainCamera.transform, timeToMoveToDoor,FadeOutExit));

    }
    private void FadeOutExit()
    {
        StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(targetAfterDoor.position, targetAfterDoor.rotation, mainCamera.transform, timeToMoveOutTheDoor));
        StartCoroutine(ObjectMoveScriptsBase3D.FadeOut(uiFadeOutImage,fadeDuration));

    }

}
