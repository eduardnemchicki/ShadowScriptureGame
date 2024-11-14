using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PuzzleScript : MonoBehaviour
{
    public static List<ClickableObject> listOfPuzzleElements = new List<ClickableObject>(); // List of all clickable objects, filled at awake by clickable objects themselves 

    public List<VictoryCondition> victoryConditions = new List<VictoryCondition>();     // «аполн€емый вручную лист условий победы.

    [SerializeField] private int maxPuzzleDepth = 10;

    [HideInInspector] public List<PuzzleObjectType> playerActionHistory = new List<PuzzleObjectType>();

    private void Start()
    {
        GameEvents.puzzleElementClicked.AddListener(CheckAllConditions);
    }
    private void CheckAllConditions(PuzzleObjectType activatedElement)
    {
        AddActionToList(activatedElement);
        if (CheckPuzzleCompletion())
        {
            GameEvents.levelComplete.Invoke();
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


