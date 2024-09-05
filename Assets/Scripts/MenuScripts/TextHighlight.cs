using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TextHighlight : MonoBehaviour
{
    [SerializeField] private MenuNames buttonType;
    [SerializeField] private MenuItemSelectScript menuController;
    [SerializeField] private SceneAsset sceneToOpen;

    [SerializeField] private Color selectedElement = Color.cyan;

    private TextMeshPro textElement;
    private Color defaultColor;
    void Awake()
    {
        this.textElement = this.GetComponent<TextMeshPro>();
        defaultColor = textElement.color;
    }

    private void OnMouseEnter()
    {
        textElement.color = selectedElement;
    }

    private void OnMouseExit()
    {
        textElement.color = defaultColor;

    }
    private void OnMouseDown()
    {
        textElement.color = defaultColor;

        if (sceneToOpen == null)
        {
            menuController.GoToSubmenu(buttonType);
        }
        else
        {
            menuController.LoadLevel(sceneToOpen);
        }
    }
}
