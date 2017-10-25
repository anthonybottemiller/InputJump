using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CockpitManager : MonoBehaviour {

    public StarshipDataManager Manager;

    // Hull A Cockpits
    public GameObject hullACockpitA;
    public GameObject hullACockpitB;
    public GameObject hullACockpitC;
    // Hull B Cockpits
    public GameObject hullBCockpitA;
    public GameObject hullBCockpitB;
    public GameObject hullBCockpitC;
    // Hull C Cockpits
    public GameObject hullCCockpitA;
    public GameObject hullCCockpitB;
    public GameObject hullCCockpitC;

    private void Start()
    {
        DisplayCurrentCockpit();
        SetCockpitColor(Manager.data.cockpitColor.ToUColor());

    }

    public int GetCurrentCockpit()
    {
        
        return Manager.data.cockpit;
    }

    public void AdvanceCockpit()
    {
        if (Manager.data.cockpit == 2)
        // If our current cockpit is our last selection
        {
            Manager.data.cockpit = 0;
            // Set it to the first selection
        }

        else
        {
            Manager.data.cockpit++;
            // Otherwise increment by one
        }

        DisplayCurrentCockpit();
    }
    public void PreviousCockpit()
    {
        if (Manager.data.cockpit == 0)
        // If our current cockpit is our first selection
        {
            Manager.data.cockpit = 2;
            // Set it to the last selection
        }

        else
        {
            Manager.data.cockpit--;
        }

        DisplayCurrentCockpit();
    }

    public void DisplayCurrentCockpit()
    {
        
        ClearCockpits();

        switch (Manager.data.cockpit)
        {
            // if current cockpit is "0" clear all cockpits and enable "A" cockpits
            case 0:
                ClearCockpits();
                DisplayCockpitA();
                break;
            // if current cockpit is "1" clear all cockpits and enable "B" cockpits
            case 1:
                ClearCockpits();
                DisplayCockpitB();
                break;
            // if current cockpit is "2" clear all cockpits and enable "C" cockpits
            case 2:
                ClearCockpits();
                DisplayCockpitC();
                break;
        }
    }

    public void DisplayCockpitA()
    // Enable all Hulls Cockpit A Game objects
    {
        hullACockpitA.SetActive(true);
        hullBCockpitA.SetActive(true);
        hullCCockpitA.SetActive(true);
    }

    public void DisplayCockpitB()
    // Enable all Hulls Cockpit B Game objects
    {
        hullACockpitB.SetActive(true);
        hullBCockpitB.SetActive(true);
        hullCCockpitB.SetActive(true);
    }

    public void DisplayCockpitC()
    // Enable all Hulls Cockpit C Game objects
    {
        hullACockpitC.SetActive(true);
        hullBCockpitC.SetActive(true);
        hullCCockpitC.SetActive(true);
    }

    public void ClearCockpits()
        // Disable all cockpit game objects
    {
        // Hull A Cockpits
        hullACockpitA.SetActive(false);
        hullACockpitB.SetActive(false);
        hullACockpitC.SetActive(false);
        // Hull B Cockpits
        hullBCockpitA.SetActive(false);
        hullBCockpitB.SetActive(false);
        hullBCockpitC.SetActive(false);
        // Hull C Cockpits
        hullCCockpitA.SetActive(false);
        hullCCockpitB.SetActive(false);
        hullCCockpitC.SetActive(false);
    }
    public void SetCockpitColor(Color newColor)
    {
        Image hullRenderer = hullACockpitA.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullACockpitB.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullACockpitC.GetComponent<Image>();
        hullRenderer.color = newColor;

        hullRenderer = hullBCockpitA.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullBCockpitB.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullBCockpitC.GetComponent<Image>();
        hullRenderer.color = newColor;

        hullRenderer = hullCCockpitA.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullCCockpitB.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullCCockpitC.GetComponent<Image>();
        hullRenderer.color = newColor;

        Manager.data.cockpitColor = SerialColor.ColorToSColor(newColor);



    }

}