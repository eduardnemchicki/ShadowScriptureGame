using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTextInteraction : MonoBehaviour
{
    [SerializeField] private Light candleLight;
    public static List<TextScript> listOfTexts = new List<TextScript>();

    private void Start()
    {
        GameEvents.paperToggle.AddListener(FlameControl);

    }
    private void FixedUpdate()
    {
        CheckAllTexts(listOfTexts);
    }

    private void FlameControl(bool shouldBeLit)
    {
        candleLight.gameObject.SetActive(!shouldBeLit);
    }

    private void CheckAllTexts(List<TextScript> texts)
    {
        RaycastHit hit;
        foreach (var text in texts)
        {
            var directionOfText = text.transform.position - this.transform.position;
            if (Physics.Raycast(transform.position, directionOfText, out hit))
            {
                
                if (hit.collider != null)
                {
                    var targetHit = hit.collider.gameObject;
                    //Light lightSource = hit.collider.GetComponent<Light>();
                    if (targetHit == text.gameObject)
                    {
                        float distance = Vector3.Distance(transform.position, hit.point);
                        float lightIntensityAtPoint = candleLight.intensity / (distance * distance);
                        text.RevealCheck(lightIntensityAtPoint);
                    }
                }
            }
        }
    }
}

