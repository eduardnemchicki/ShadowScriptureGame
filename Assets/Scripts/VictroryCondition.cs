using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [AI OVERVIEW] Abstract ScriptableObject victory rules evaluated against PuzzleScript (playerActionHistory, listOfPuzzleElements via ClickableObject). Concrete assets: NoSuchObject, ClickSequence, LastActionType. Designed to be assigned on PuzzleScript in the inspector.
public abstract class VictoryCondition : ScriptableObject
{
    public abstract bool IsConditionMet(PuzzleScript actionHistory);
}

// [AI OVERVIEW] Wins when no ClickableObject in PuzzleScript.listOfPuzzleElements has elementType == typeThatShouldNotExist.
[CreateAssetMenu(fileName = "Condition_NoObjectOfType", menuName = "Puzzle/VictoryCondition_NoSuchObject")]
public class VictoryCondition_NoSuchObject : VictoryCondition
{
    public PuzzleObjectType typeThatShouldNotExist;
    //public bool otherConditionShouldBeTrueFirst;
    //public VictoryCondition secondaryCondition;

    public override bool IsConditionMet(PuzzleScript puzzleManager)
    {
        if (!PuzzleScript.listOfPuzzleElements.Any(x => x.elementType == typeThatShouldNotExist))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

// [AI OVERVIEW] Wins when the tail of PuzzleScript.playerActionHistory matches requiredSequence (PuzzleObjectType order).
[CreateAssetMenu(fileName = "Condition_ClickSequence", menuName = "Puzzle/VictoryCondition_ClickSequence")]
public class VictoryCondition_ClickSequence : VictoryCondition
{
    public PuzzleObjectType[] requiredSequence; //filled manually

    public override bool IsConditionMet(PuzzleScript puzzleManager)
    {
        if (puzzleManager.playerActionHistory.Count < requiredSequence.Length)
        {
            return false;
        }

        int offset = 0;
        if (puzzleManager.playerActionHistory.Count > requiredSequence.Length)
        { 
            offset = puzzleManager.playerActionHistory.Count - requiredSequence.Length;
        }

        for (int i = 0; i < requiredSequence.Length; i++)
        {
            if (puzzleManager.playerActionHistory[i] != requiredSequence[offset+i])
                return false;
        }
        return true;
    }
}



// [AI OVERVIEW] Wins when the last numberOfObjects entries in playerActionHistory (with offsetFromEnd) are all in typesOfPress.
[CreateAssetMenu(fileName = "Condition_LastActionType", menuName = "Puzzle/VictoryCondition_LastActionType")]
public class VictoryCondition_LastActionType : VictoryCondition
{
    public List<PuzzleObjectType> typesOfPress = new List<PuzzleObjectType>();
    public int numberOfObjects = 1;
    public int offsetFromEnd = 0;

    public override bool IsConditionMet(PuzzleScript puzzleManager)
    {
        int fullOffset = offsetFromEnd + numberOfObjects;
        if (puzzleManager.playerActionHistory.Count < fullOffset)
        {
            return false;
        }
        for (int i = puzzleManager.playerActionHistory.Count - fullOffset; i < puzzleManager.playerActionHistory.Count - offsetFromEnd ; i++) 
        {
            if (!typesOfPress.Contains(puzzleManager.playerActionHistory[i]))
                return false;
        }

        return true;
    }

}