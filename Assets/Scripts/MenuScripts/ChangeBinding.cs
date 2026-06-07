using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeBinding : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ControlNames controlToChange;
    bool isWaitingForKeyPress = false; 
    private static bool eventAlreadySent;

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
                        if (ControlList.controlsDictionary.ContainsValue(key))
                        {
                            var tmpKey = ControlList.controlsDictionary.First(x => x.Value == key).Key;
                            ControlList.ChangeControlButton(tmpKey, ControlList.controlsDictionary[controlToChange]);
                        }

                        ControlList.ChangeControlButton(controlToChange, key);

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
