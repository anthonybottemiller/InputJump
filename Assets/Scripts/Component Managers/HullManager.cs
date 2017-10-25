using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HullManager : MonoBehaviour {

    private void Start()
    {
        DisplayHull();
        SetHullColor(Manager.data.hullColor.ToUColor());

    }
    // Declaring GameObjects for the Hulls that will be toggled on or off.
    public GameObject hullA;
    public GameObject hullB;
    public GameObject hullC;

    public StarshipDataManager Manager;

    // Declaring int for keeping track of current hull selected state

    public void SetHullColor(Color newColor)
    {
        Image hullRenderer = hullA.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullB.GetComponent<Image>();
        hullRenderer.color = newColor;
        hullRenderer = hullC.GetComponent<Image>();
        hullRenderer.color = newColor;
        Manager.data.hullColor = SerialColor.ColorToSColor(newColor);
    }

    public void AdvanceHull()
    {
        // This method is intended to advance hull choice to the next option enabling and disabling the associated game objects
        if (Manager.data.hull == 2)
            // If our current hull is our last selection
        {
            Manager.data.hull = 0;
            // Set it back to the beginning
        }

        else
        {
            Manager.data.hull++;
            // Otherwise increment by one
        }

        DisplayHull();
    }

    public void PreviousHull()
    {
        if (Manager.data.hull == 0)
        // If our current hull is our first selection
        {
            Manager.data.hull = 2;
            // Set it to the last selection
        }

        else
        {
            Manager.data.hull--;
            // Otherwise decrement by one
        }

        DisplayHull();
    }

    public void DisplayHull()
    {

        ClearHull();

        switch (Manager.data.hull)
        // Using the private property current Hull figure out which hull should be displayed
        // Then turn on desired hull
        {
            case 0:
                hullA.SetActive(true);
                break;
            case 1:
                hullB.SetActive(true);
                break;
            case 2:
                hullC.SetActive(true);
                break;
        }

    }

    public void ClearHull()
    // Disable all hull game objects
    {
        hullA.SetActive(false);
        hullB.SetActive(false);
        hullC.SetActive(false);
    }

    public void SetHull(int desiredHull)
    // Set hull in Starship data manager
    {
        Manager.data.hull = desiredHull;
        DisplayHull();
    }

    public int GetCurrentHull()
    {
        return Manager.data.hull;
    }

}
