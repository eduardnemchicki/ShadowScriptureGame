using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class VictoryCondition : ScriptableObject
{
    public abstract bool IsConditionMet(PuzzleScript puzzleManager);
}

[CreateAssetMenu(fileName = "Condition_AllElementsInState", menuName = "Puzzle/VictoryCondition_AllElementsInState")]
public class VictoryCondition_AllElementsInState : VictoryCondition
{
    public PuzzleObjectType[] requiredTypes;
    public bool requiredState; // True for On/Lit, False for Off/Unlit

    public override bool IsConditionMet(PuzzleScript puzzleManager)
    {
        
        foreach (var type in requiredTypes)
        {
            var element = manager.GetElementByType(type);
            if (element == null || element.isActive != requiredState)
                return false;
        }
        return true;
    }
}

[CreateAssetMenu(fileName = "Condition_ClickSequence", menuName = "Puzzle/VictoryCondition_ClickSequence")]
public class VictoryCondition_ClickSequence : VictoryCondition
{
    public PuzzleObjectType[] requiredSequence;

    public override bool IsConditionMet(PuzzleScript manager)
    {
        if (manager.playerClickSequence.Count < requiredSequence.Length)
            return false;

        for (int i = 0; i < requiredSequence.Length; i++)
        {
            if (manager.playerClickSequence[i] != requiredSequence[i])
                return false;
        }
        return true;
    }
}