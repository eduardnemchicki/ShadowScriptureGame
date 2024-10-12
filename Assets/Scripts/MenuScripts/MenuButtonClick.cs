using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextHighlight))]
public class MenuButtonClick : MonoBehaviour, IPointerClickHandler
{
    //just a copy of MenuButtonInteraction class, but for use with MenuManager

    [SerializeField] private TextHighlight textHighlight;
    [SerializeField] private SceneAsset sceneToOpen;
    [SerializeField] private MenuNames buttonType;
    [SerializeField] private MenuManager menuItemSelectorScript;

    public void OnPointerClick(PointerEventData eventData)
    {
        textHighlight.toggleColor(false);

        if (buttonType == MenuNames.ToNewLevel)
        {
            menuItemSelectorScript.LoadLevel(sceneToOpen);
        }
        else
        {
            menuItemSelectorScript.GoToSubmenu(buttonType);
        }
    }

    private void Awake()
    {
        if (textHighlight == null) // if i get too lasy to assign it all by hand
        {
            textHighlight = this.gameObject.GetComponent<TextHighlight>();
        }
    }
}
