using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIInterface : MonoBehaviour {

    public Text DestinationDisplay;
    public Text DestinationDisplayInfoPanel;

    public Text BriefingText;

    public Text DistanceDataDisplay;

    public Text ConstellationData;

    public Text DiscoveryText;

    public Text DebriefingSystemLabel;

    public Text SystemData;

    public GameObject SystemInfoPanel;
    public GameObject DebriefingPanel;

    private void Start()
    {
        UpdateDestination("?");
    }

    public void UpdateDestination(string newDestination)
    {
        DestinationDisplay.text = newDestination;
        DestinationDisplayInfoPanel.text = newDestination;
    }

    public void UpdateBasicInfo(string newString)
    {
        BriefingText.text = newString;
    }

    public void UpdateDistanceInfo(float distance)
    {
       DistanceDataDisplay.text = distance.ToString() + " Light Years";
    }

    public void UpdateConstellationData(string newData)
    {
        ConstellationData.text = newData;
    }

    public void UpdateDiscoveryText(string newText)
    {
        DiscoveryText.text = newText;
    }

    public void UpdateDebriefingSystem(string newSystem)
    {
        DebriefingSystemLabel.text = "You made it to " + newSystem + "!!";
    }

    public void UpdateSystemData(string newData)
    {
        SystemData.text = newData;
    }

    public void SetInfoPanelActive(bool setting)
    {
        SystemInfoPanel.SetActive(setting);
    }

    public void SetDebriefingPanelActive(bool setting)
    {
        DebriefingPanel.SetActive(setting);
    }
}
