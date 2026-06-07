using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [AI OVERVIEW] Static coroutine utilities: smooth Transform lerp (position/rotation) with optional callback, and UI Image fade to black. Used by ObjectMoveScript (paper up/down) and RoundVictoryScript (camera exit sequence).
public static class ObjectMoveScriptsBase3D 
{
    //public static IEnumerator MoveToTarget(Vector3 newPlace, Quaternion newRotation, Transform objectToMove, float timeToMove)
    //{
    //    yield return MoveToTargetInternal(newPlace, newRotation, objectToMove, timeToMove);
    //}

    public static IEnumerator MoveToTarget(Vector3 newPlace, Quaternion newRotation, Transform objectToMove, float timeToMove, Action onComplete = null)
    {
        yield return MoveToTargetInternal(newPlace, newRotation, objectToMove, timeToMove);
        onComplete?.Invoke();
    }



    private static IEnumerator MoveToTargetInternal(Vector3 newPlace, Quaternion newRotation, Transform objectToMove, float timeToMove)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = objectToMove.position;
        Quaternion startingRotation = objectToMove.rotation;

        while (elapsedTime < timeToMove)
        {
            float curTimeSlot = elapsedTime / timeToMove;
            objectToMove.position = Vector3.Lerp(startingPosition, newPlace, curTimeSlot);  // Smooth movement
            objectToMove.rotation = Quaternion.Lerp(startingRotation, newRotation, curTimeSlot);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.position = newPlace;  // Ensures it ends exactly at the target position
        objectToMove.rotation = newRotation;
    }
    public static IEnumerator FadeOut(Image imageToFade, float timeToFullFade, Color finalColor = default)
    {
        if (finalColor == default) 
        {
            finalColor = new Color(0, 0, 0, 1);
        }
        float elapsedTime = 0f;

        //Color startColor = imageToFade.color;
        Color startColor = new Color(0, 0, 0, 0);
        imageToFade.color = startColor;

        while (elapsedTime < timeToFullFade)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / timeToFullFade);
            imageToFade.color = Color.Lerp(startColor, finalColor, alpha);
            yield return null;
        }
        imageToFade.color = finalColor; // Ensure it's fully black after fade-out
    }
}
