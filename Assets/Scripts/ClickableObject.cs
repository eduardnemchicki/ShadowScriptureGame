using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

// [AI OVERVIEW] Puzzle interactable on 3D objects. Registers with PuzzleScript.listOfPuzzleElements; listens to GameEvents.paperToggle for click enable; on mouse click plays AudioSource and toggles candle ParticleSystems, then invokes GameEvents.puzzleElementClicked with PuzzleObjectType. Uses PuzzleObjectType enum; expects AudioSource and child particle lights on candle objects.
public class ClickableObject : MonoBehaviour
{
    public PuzzleObjectType elementType;
    private Material highlightMat;
    //[SerializeField] private string elementType;
    private bool clickable;
    private AudioSource attachedAudio = null;
    List<ParticleSystem> lights = new List<ParticleSystem>();
    List<Material> defaultMats = new List<Material>();


    private void Start()
    {
        clickable = false;
        GameEvents.textHighlightToggle.AddListener(HighLight);

        GameEvents.paperToggle.AddListener((x) => clickable = x);
        highlightMat = CommonItemHager.highlightMat;
        foreach (var renderer in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            defaultMats.Add(renderer.material);
        }

        try
        {
            attachedAudio = this.gameObject.GetComponent<AudioSource>();
        }
        catch
        {
            attachedAudio = null;
        }



        PuzzleScript.listOfPuzzleElements.Add(this);
        if(elementType == PuzzleObjectType.CandlesLit || elementType == PuzzleObjectType.CandlesNotLit)
        {
            lights.AddRange(gameObject.GetComponentsInChildren<ParticleSystem>(true));
        }
       
    }
    private void HighLight(bool shouldHighlight)
    {
        if (shouldHighlight)
        {
            foreach (var renderer in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                renderer.material = highlightMat;
            }
        }
        else
        {
            int i = 0;
            foreach (var renderer in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                renderer.material = defaultMats[i];
                i++;
            }
        }
    }
    void OnMouseDown()
    {
        //GameEvents.puzzleElementClicked.Invoke(this.gameObject, elementType);
        if (!clickable)
        {
            return;
        }
        if(attachedAudio != null)
        {
            attachedAudio.Play();
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
                //this.gameObject.GetComponent<AudioSource>().Play();
                break;
            case PuzzleObjectType.Chain: 
                //this.gameObject.GetComponent<AudioSource>().Play();
                break;
            default:
                break;
        }

        GameEvents.puzzleElementClicked.Invoke(elementType);

    }
}
