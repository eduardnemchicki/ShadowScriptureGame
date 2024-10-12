using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color elementToggledColor = Color.cyan;

    private TextMeshProUGUI textElement;
    private Color defaultColor;
    void Awake()
    {
        this.textElement = this.gameObject.GetComponent<TextMeshProUGUI>();
        defaultColor = textElement.color;
        GameEvents.pauseMenuToggle.AddListener(() => toggleColor(false));
    }

    public void toggleColor(bool colorShouldBeDefault)
    {
        textElement.color = colorShouldBeDefault ? elementToggledColor : defaultColor;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.toggleColor(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.toggleColor(false);
    }
}
