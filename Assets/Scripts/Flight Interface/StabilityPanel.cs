using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabilityPanel : MonoBehaviour
{
    public Color BarOffColor;
    public Color BarOnColor;
    public int ColorDefault;
    public List<GameObject> StabilityBars;
    public List<Image> BarRenderers;
    int BarsIlluminated = 6;



    // Use this for initialization
    void Start()
    {
        foreach (GameObject Bar in StabilityBars)
        {
            // Get Reference to panels sprite renderer check if null and put it in the renderers list
            Image NewRenderer = Bar.GetComponent<Image>();
            if (NewRenderer != null) { BarRenderers.Add(NewRenderer); }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetStability()
    {
        BarsIlluminated = 6;
        ChangeAllBarColors();
    }

    public void ChangeAllBarColors()
    {
        foreach (Image Renderer in BarRenderers)
        {
            Renderer.color = BarOnColor;
        }
    }
    public void TurnOnIndicator()
    {
        if(BarRenderers.Count > BarsIlluminated)
        {
            BarRenderers[BarsIlluminated].color = BarOnColor;
            BarsIlluminated++;
        }
    }

    public void TurnOffIndicator()
    {
        BarsIlluminated--;
        BarRenderers[BarsIlluminated].color = BarOffColor;
        Debug.Log(BarsIlluminated);
    }



    public void TurnOffIndicator(int NumberToTurnOff)
    {
        for (var i = NumberToTurnOff; i > 0; i--)
        {
            if (BarsIlluminated >= 0)
            {
                BarsIlluminated--;
                BarRenderers[BarsIlluminated].color = BarOffColor;
            }
        }
    }
}