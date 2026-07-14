using UnityEngine;
using UnityEngine.EventSystems;

public class KeysScript : MonoBehaviour, IPointerClickHandler
{
    private static bool isKeyPressed = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isKeyPressed)
        {
            isKeyPressed = true;
            GameEvents.levelComplete.Invoke();
        }
        
    }
    public void OnMouseUp()
    {
        if (!isKeyPressed)
        {
            isKeyPressed = true;
            GameEvents.levelComplete.Invoke();
        }
    }
}
