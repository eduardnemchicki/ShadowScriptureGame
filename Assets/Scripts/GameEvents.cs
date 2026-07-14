using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [AI OVERVIEW] Central static event bus for cross-scene gameplay. paperToggle: ControlsUsage, ClickableObject, ObjectMoveScript, CandleMovement, CandleTextInteraction. puzzleElementClicked: ClickableObject (listeners expected on PuzzleScript). levelComplete: RoundVictoryScript. pauseMenuToggle: ControlsUsage, OpenMainMenuScript, TextHighlight.
public static class GameEvents
{
    public static UnityEvent<bool> paperToggle = new UnityEvent<bool>();
    //public static UnityEvent instrumentFinishedMove = new UnityEvent();
    public static UnityEvent<PuzzleObjectType> puzzleElementClicked = new UnityEvent<PuzzleObjectType>();
    public static UnityEvent levelComplete = new UnityEvent();
    public static UnityEvent endSequanceFinish = new UnityEvent();
    public static UnityEvent pauseMenuToggle = new UnityEvent();

    public static UnityEvent<bool> objectHighlightToggle = new UnityEvent<bool>();
    public static UnityEvent<bool> blockMenuButtons = new UnityEvent<bool>();
}
