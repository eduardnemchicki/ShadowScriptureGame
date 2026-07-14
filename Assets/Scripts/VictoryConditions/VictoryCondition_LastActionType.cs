using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Condition_LastActionType", menuName = "Puzzle/VictoryCondition_LastActionType")]
public class VictoryCondition_LastActionType : VictoryCondition
{
    public List<PuzzleObjectType> typesOfPress = new List<PuzzleObjectType>();// lists all aceptable objects
    public int numberOfObjects = 1; // number of times types of object from typesOfPress need to be pressed in a row
    public int offsetFromEnd = 0; // how many actions should be in a puzzle solution AFTER this one.

    public override bool IsConditionMet(PuzzleScript puzzleManager)
    {
        int fullOffset = offsetFromEnd + numberOfObjects;
        if (puzzleManager.playerActionHistory.Count < fullOffset)
        {
            return false;
        }
        for (int i = puzzleManager.playerActionHistory.Count - fullOffset; i < puzzleManager.playerActionHistory.Count - offsetFromEnd; i++)
        {
            if (!typesOfPress.Contains(puzzleManager.playerActionHistory[i]))
                return false;
        }

        return true;
    }

}
