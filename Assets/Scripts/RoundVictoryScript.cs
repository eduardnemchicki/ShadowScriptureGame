using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [AI OVERVIEW] Plays level-complete exit: subscribes to GameEvents.levelComplete, moves mainCamera via ObjectMoveScriptsBase3D to door targets, plays door Animator, fades uiFadeOutImage. Serialized Camera, Transforms, Animator, and UI Image.
public class RoundVictoryScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform targetBeforeDoor;
    [SerializeField] private Transform targetAfterDoor;
    [SerializeField] private Animator doorAnimation;
    [SerializeField] private Image uiFadeOutImage;

    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioSource audioSource;
    //timers
    [SerializeField] private float fadeDuration = 2f; // Duration of the fade
    [SerializeField] private float fadeDelay = 1f;
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
        audioSource.PlayOneShot(doorOpenSound);
        StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(targetBeforeDoor.position, targetBeforeDoor.rotation, mainCamera.transform, timeToMoveToDoor,FadeOutExit));

    }
    private void FadeOutExit()
    {
        StartCoroutine(ObjectMoveScriptsBase3D.MoveToTarget(targetAfterDoor.position, targetAfterDoor.rotation, mainCamera.transform, timeToMoveOutTheDoor));
        
        StartCoroutine(ObjectMoveScriptsBase3D.FadeOut(uiFadeOutImage,fadeDuration, fadeDelay));

    }

}
