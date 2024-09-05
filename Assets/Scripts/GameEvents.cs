using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent<bool> paperToggle = new UnityEvent<bool>();
    //public static UnityEvent instrumentFinishedMove = new UnityEvent();
    public static UnityEvent<PuzzleObjectType> puzzleElementClicked = new UnityEvent<PuzzleObjectType>();
    public static UnityEvent levelComplete = new UnityEvent();
}
