using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public PuzzleObjectType elementType;
    //[SerializeField] private string elementType;
    private bool clickable;
    List<ParticleSystem> lights = new List<ParticleSystem>();

    private void Start()
    {
        clickable = false;
        GameEvents.paperToggle.AddListener((x) => clickable = x);

        PuzzleScript.listOfPuzzleElements.Add(this);
        if(elementType == PuzzleObjectType.CandlesLit || elementType == PuzzleObjectType.CandlesNotLit)
        {
            lights.AddRange(gameObject.GetComponentsInChildren<ParticleSystem>(true));
        }
       
    }
    void OnMouseDown()
    {
        //GameEvents.puzzleElementClicked.Invoke(this.gameObject, elementType);
        if (!clickable)
        {
            return;
        }
        switch (elementType)
        {
            case PuzzleObjectType.CandlesLit:

                foreach (var light in lights)
                {
                    light.gameObject.SetActive(false);
                }
                elementType = PuzzleObjectType.CandlesNotLit; ;
                break;

            case PuzzleObjectType.CandlesNotLit:

                foreach (var light in lights)
                {
                    light.gameObject.SetActive(true);
                }
                elementType = PuzzleObjectType.CandlesLit;
                break;

            case PuzzleObjectType.Cage:
                this.gameObject.GetComponent<AudioSource>().Play();
                break;
            case PuzzleObjectType.Chain: 
                this.gameObject.GetComponent<AudioSource>().Play();
                break;
            default:
                break;
        }

        GameEvents.puzzleElementClicked.Invoke(elementType);

    }
}
