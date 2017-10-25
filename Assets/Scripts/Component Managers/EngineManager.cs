using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineManager : MonoBehaviour {

    // Declaring GameObjects for the engines that will be toggled on or off.
    public GameObject engineA;
    public GameObject engineB;
    public GameObject engineC;

    public StarshipDataManager Manager;



    private void Start()
    {
        DisplayEngine();
        SetEngineColor(Manager.data.engineColor.ToUColor());
    }

    // Declaring int for keeping track of current engine selected state

    public void AdvanceEngine()
    {
        // This method is intended to advance engine choice to the next option enabling and disabling the associated game objects
        if (Manager.data.engine == 2)
            // If our current engine is our last selection
        {
            Manager.data.engine = 0;
            // Set it back to the beginning
        }

        else
        {
            Manager.data.engine++;
            // Otherwise increment by one
        }
        DisplayEngine();
    }

    public void PreviousEngine()
    {
        if (Manager.data.engine == 0)
        // If our current engine is our first selection
        {
            Manager.data.engine = 2;
            // Set it to the last selection
        }

        else
        {
            Manager.data.engine--;
            // Otherwise decrement by one
        }
        DisplayEngine();
    }

    public void DisplayEngine()
    {
        ClearEngines();
        switch (Manager.data.engine)
        // Using the private property current engine figure out which engine should be displayed
        // Then turn on desired engine
        {
            case 0:
                engineA.SetActive(true);
                break;
            case 1:
                engineB.SetActive(true);
                break;
            case 2:
                engineC.SetActive(true);
                break;
        }

    }

    public void ClearEngines()
        // Turn off all engine game objects
    {
        engineA.SetActive(false);
        engineB.SetActive(false);
        engineC.SetActive(false);
    }

    public int GetCurrentEngine()
    {
        return Manager.data.engine;
    }

    public void SetEngineColor(Color newColor)
    {
        Image hullRenderer = engineA.GetComponentInChildren<Image>();
        hullRenderer.color = newColor;
        hullRenderer = engineB.GetComponentInChildren<Image>();
        hullRenderer.color = newColor;
        hullRenderer = engineC.GetComponentInChildren<Image>();
        hullRenderer.color = newColor;
        Manager.data.engineColor = SerialColor.ColorToSColor(newColor);

    }

}
