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
