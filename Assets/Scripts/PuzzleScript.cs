using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PuzzleObjectType
{
    CandlesLit = 0,
    CandlesNotLit = 1,
    Chain = 2,
    Cage = 3,
    Barrel = 4,
}


public class PuzzleScript: MonoBehaviour
{
    [SerializeField] private List<PuzzleObjectType> puzzle = new List<PuzzleObjectType>();

    private List<PuzzleObjectType> playerActions = new List<PuzzleObjectType>();
    private void Start()
    {
        GameEvents.puzzleElementClicked.AddListener(CheckPuzzleProgress);
    }

    private void CheckPuzzleProgress(PuzzleObjectType type)
    {
        bool solutionFound = true;
        playerActions.Add(type);
        for (int i = 0; i < playerActions.Count; i++) 
        {
            if(playerActions[i] != puzzle[i])
            {
                playerActions.Clear();
                solutionFound = false;
                break;
            }
        }
        if (solutionFound) 
        {
            GameEvents.levelComplete.Invoke();
        }
    }
}

public class PuzzlePiece
{
    public PuzzleObjectType type;
    public string name;
}