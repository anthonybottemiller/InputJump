using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCockpitManager : MonoBehaviour {

    public StarshipDataManager Manager;

    // Declaring GameObjects for the Hulls that will be toggled on or off.
    public GameObject previewCockpitA;
    public GameObject previewCockpitB;
    public GameObject previewCockpitC;

    // Declaring int for keeping track of current hull selected state

    private void Start()
    {
        DisplayCurrentCockpit();
    }

    public void AdvancePreview()
    {
        // This method is intended to advance hull choice to the next option enabling and disabling the associated game objects
        if (Manager.data.cockpit == 2)
            // If our current hull is our last selection
        {
            Manager.data.cockpit = 0;
            // Set it back to the beginning
        }

        else
        {
            Manager.data.cockpit++;
            // Otherwise increment by one
        }

        switch(Manager.data.cockpit)
            // Using the private property current Hull figure out which hull should be displayed
            // Turn off other hull objects first
            // Then turn on desired hull
        {
            case 0:
                previewCockpitB.SetActive(false);
                previewCockpitC.SetActive(false);
                previewCockpitA.SetActive(true);
                break;
            case 1:
                previewCockpitA.SetActive(false);
                previewCockpitC.SetActive(false);
                previewCockpitB.SetActive(true);
                break;
            case 2:
                previewCockpitA.SetActive(false);
                previewCockpitB.SetActive(false);
                previewCockpitC.SetActive(true);
                break;
        }
    }

    public void PreviousPreview()
    {
        if (Manager.data.cockpit == 0)
        // If our current hull is our first selection
        {
            Manager.data.cockpit = 2;
            // Set it to the last selection
        }

        else
        {
            Manager.data.cockpit--;
            // Otherwise decrement by one
        }

        switch (Manager.data.cockpit)
            // Using the private property current Hull figure out which hull should be displayed
            // Turn off other hull objects first
            // Then turn on desired hull
        {
            case 0:
                previewCockpitA.SetActive(true);
                break;
            case 1:
                previewCockpitB.SetActive(true);
                break;
            case 2:
                previewCockpitC.SetActive(true);
                break;
        }

    }

    public void DisplayCurrentCockpit()
    {
        ClearCockpits();

        switch (Manager.data.cockpit)
        // Using the private property current Hull figure out which hull should be displayed
        // Then turn on desired hull
        {
            case 0:
                previewCockpitA.SetActive(true);
                break;
            case 1:
                previewCockpitB.SetActive(true);
                break;
            case 2:
                previewCockpitC.SetActive(true);
                break;
        }

    }

    void ClearCockpits()
    // Disable all cockpit game objects
    {
        previewCockpitA.SetActive(false);
        previewCockpitB.SetActive(false);
        previewCockpitC.SetActive(false);
    }
}
