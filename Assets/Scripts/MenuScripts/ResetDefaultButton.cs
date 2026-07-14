using UnityEngine;
using UnityEngine.EventSystems;

public class ResetDefaultButton : MonoBehaviour
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ControlList.ResetControlsToDefault();
        GameEvents.blockMenuButtons.Invoke(false);
    }
}
