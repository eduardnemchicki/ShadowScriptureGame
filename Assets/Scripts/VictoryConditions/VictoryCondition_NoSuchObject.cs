using System.Linq;
using UnityEngine;

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

