using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeBinding : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ControlNames controlToChange;
    bool isWaitingForKeyPress = false; 
    private static bool eventAlreadySent; //to block other thigns happening while waiting for key press, like going back to main menu or opening other menus
    private static List<KeyCode> reservedKeys = new List<KeyCode> { KeyCode.Delete, KeyCode.Mouse0}; //reserved keys that cannot be used for controls
    void Awake()
    {
        textUpdate();
        GameEvents.blockMenuButtons.AddListener(x => { 
            if (x) { 
                isWaitingForKeyPress = true;
            }
            else
            { 
                textUpdate(); 
                isWaitingForKeyPress = false;
            } 
        });
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isWaitingForKeyPress)
        {
            this.GetComponent<TMPro.TMP_Text>().text = "Press new key...";
            StartCoroutine(WaitForKeyPress());
        }
    }

    

    private void textUpdate()
    {
        this.GetComponent<TMPro.TMP_Text>().text = ControlList.controlsDictionary[controlToChange].ToString();
    }

    private IEnumerator WaitForKeyPress()
    {
        GameEvents.blockMenuButtons.Invoke(true);

        yield return new WaitUntil(() =>
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        if (!reservedKeys.Contains(key))
                        {

                            if (ControlList.controlsDictionary.ContainsValue(key))
                            {
                                var tmpKey = ControlList.controlsDictionary.First(x => x.Value == key).Key;
                                ControlList.ChangeControlButton(tmpKey, ControlList.controlsDictionary[controlToChange]);
                            }

                            ControlList.ChangeControlButton(controlToChange, key);
                            ControlList.SaveControlsToFile();
                        }
                        GameEvents.blockMenuButtons.Invoke(false);
                        return true;
                    }
                }
                return false;
            });

    }
    private void OnDisable()
    {
        StopAllCoroutines();

        if (eventAlreadySent)
            return;

        eventAlreadySent = true;
        GameEvents.blockMenuButtons.Invoke(false);
    }
    private void OnEnable()
    {
        eventAlreadySent = false;
    }
}
