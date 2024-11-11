using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum PuzzleObjectType
{
    CandlesLit = 0,
    CandlesNotLit = 1,
    Chain = 2,
    Cage = 3,
    Barrel = 4,
}
public enum PuzzleConditonType
{
    LightsOff,
    LightsOn,
    LightsToggle,
    ClickSequance,
    AnySound
}



public class PuzzleScript: MonoBehaviour
{
    public static List<ClickableObject> listOfPuzzleElements = new List<ClickableObject>();

    [SerializeField] private List<PuzzleObjectType> clickSequanceSolution = new List<PuzzleObjectType>();   // последовательность кликов, которая нужна для выполнения условия

    [SerializeField] private List<PuzzleConditonType> puzzleSolution = new List<PuzzleConditonType>();      // скорее всего нужно поменять, сейчас это два списка делающих по сути одно и то же

    private List<PuzzleObjectType> playerClickSequance = new List<PuzzleObjectType>();

    private List<PuzzleConditonType> playerActions = new List<PuzzleConditonType>();

    //bool clickSequenceCompleted = false;
    //bool allLightsOff = false;
    //bool allLightsOn = false;
    //private bool soundWasMade;
    [SerializeField] private bool sequenceMatters;
    
    private void Start()
    {
        GameEvents.puzzleElementClicked.AddListener(CheckAllConditions);
    }
    private void CheckAllConditions(PuzzleObjectType activatedElement)
    {
        CheckLights();
        CheckClickSequance(activatedElement);           // Нужно переработать систему проверки
        CheckSound(activatedElement);

        CheckPuzzleCompletion(playerActions,puzzleSolution);
    }

    private void CheckSound(PuzzleObjectType activatedElement)
    {
        var soundMakingElements = new[] { PuzzleObjectType.Barrel, PuzzleObjectType.Chain, PuzzleObjectType.Cage };
        if (soundMakingElements.Contains(activatedElement))
        {
            playerActions.Add(PuzzleConditonType.AnySound);
        }
    }
    private void CheckLights()
    {
        if (!listOfPuzzleElements.Any(x=> x.elementType == PuzzleObjectType.CandlesLit))
        {
            playerActions.Add(PuzzleConditonType.LightsOff);
        }
        else if (!listOfPuzzleElements.Any(x => x.elementType == PuzzleObjectType.CandlesNotLit)) 
        {
            playerActions.Add(PuzzleConditonType.LightsOn);
        }

    }

    private void CheckClickSequance(PuzzleObjectType type)
    {
        bool solutionFound = true;
        playerClickSequance.Add(type);
        for (int i = 0; i < playerClickSequance.Count; i++) 
        {
            if(playerClickSequance[i] != clickSequanceSolution[i])
            {
                playerClickSequance.Clear();
                solutionFound = false;
                break;
            }
        }
        if (solutionFound) 
        {
            playerActions.Add(PuzzleConditonType.ClickSequance);
        }
    }

    private void CheckPuzzleCompletion(List<PuzzleConditonType> actionList, List<PuzzleConditonType> finalGoalList)
    {

        if (actionList.Count > finalGoalList.Count)
        {
            actionList.Clear(); // it should not happen ever
        }
        for (int i = 0; i < actionList.Count; i++)
        {
            if (actionList[i] != finalGoalList[i])
            {
                actionList.Clear();
                return;
            }
        }
        if (actionList.Count > 0) 
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


