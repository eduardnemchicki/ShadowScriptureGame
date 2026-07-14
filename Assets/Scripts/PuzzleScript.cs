using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;


public class PuzzleScript : MonoBehaviour
{
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip puzzleCompleteSound;
    public static List<ClickableObject> listOfPuzzleElements = new List<ClickableObject>(); // List of all clickable objects, filled at awake by clickable objects themselves 
    
    public List<VictoryCondition> victoryConditions = new List<VictoryCondition>();     // «аполн€емый вручную лист условий победы.

    private bool puzzleCompleted;

    [SerializeField] private int maxPuzzleDepth = 10;

    [HideInInspector] public List<PuzzleObjectType> playerActionHistory = new List<PuzzleObjectType>();

    private void Start()
    {
        keyObject.SetActive(false);
        puzzleCompleted = false;
        GameEvents.puzzleElementClicked.AddListener(CheckAllConditions);
    }
    private void CheckAllConditions(PuzzleObjectType activatedElement)
    {
        AddActionToList(activatedElement);
        if (CheckPuzzleCompletion() && !puzzleCompleted)
        {
            keyObject.SetActive(true);
            puzzleCompleted = true;

            audioSource.clip = puzzleCompleteSound;
            audioSource.Play();
            //GameEvents.levelComplete.Invoke();
            //GameEvents.puzzleElementClicked.RemoveListener(CheckAllConditions);
        }
    }

    private void AddActionToList(PuzzleObjectType activatedElement)
    {
        playerActionHistory.Add(activatedElement);

        if (maxPuzzleDepth < playerActionHistory.Count)
        {
            playerActionHistory.RemoveAt(0);
        }
    }

    private bool CheckPuzzleCompletion()
    {
        bool isPuzzleComplete = true;

        foreach (VictoryCondition condition in victoryConditions)
        {
            if (!condition.IsConditionMet(this))
            {
                isPuzzleComplete = false;
                break;
            }
        }
        return isPuzzleComplete;
    }

    
}


