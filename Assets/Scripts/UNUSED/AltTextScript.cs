using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AltTextScript : MonoBehaviour
{
    public string secretText;
    private TextMeshPro textMesh;
    public float minLight = 10;
    public float maxLight = 20;

    private bool secretRevealed;

    private void Awake()
    {
        secretRevealed = true;
        textMesh = GetComponent<TextMeshPro>();
        //CandleTextInteraction.listOfTexts.Add(this);
    }
    void FixedUpdate()
    {
        //Light candle = CommonItemHager.candleLight;
        //if (candle != null)
        //{
        //    float distance = Vector3.Distance(transform.position, candle.transform.position);
        //    float lightIntensityAtPoint = candle.intensity / (distance * distance);
        //    //Debug.Log("Light Intensity at Point: " + lightIntensityAtPoint);

        //    secretText = lightIntensityAtPoint.ToString();
        //    RevealCheck(lightIntensityAtPoint);
        //}

    }

    public void RevealCheck(float currentLightLvl)
    {
        if (currentLightLvl > minLight && currentLightLvl < maxLight)
        {
            if (!secretRevealed)
            {
                textMesh.text = secretText;
                secretRevealed = true;
            }
        }
        else if (secretRevealed)
        {
            textMesh.text = "";
            secretRevealed = false;
        }
    }
}
