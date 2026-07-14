using UnityEngine;

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
            if (puzzleManager.playerActionHistory[i] != requiredSequence[offset + i])
                return false;
        }
        return true;
    }
}
