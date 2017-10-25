using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject FlightInterface;

    public PlayerDataManager PlayerData;

    public Text OutputTerm1;
    public Text OutputTerm2;
    public Text OutputOperator;
    public Text Input;

    public GameObject CorrectLight;
    public GameObject ErrorLight;

    public MissionManager MissionManager;

    ProblemGenerator Generator = new ProblemGenerator();

    PanelController Panels;
    StabilityPanel StabilityPanel;
    SolutionDisplay SolutionDisplay;
    JumpTracker JumpTracker;
    InfoUIInterface InfoUIInterface;

    TenKeyPrompt TenKeyPrompt;

    CoolDownPanel CoolDownPanel;

    int lives = 6;

    // Use this for initialization
    void Start()
    {
        Panels = FlightInterface.GetComponent<PanelController>();
        StabilityPanel = FlightInterface.GetComponent<StabilityPanel>();
        SolutionDisplay = FlightInterface.GetComponent<SolutionDisplay>();
        JumpTracker = FlightInterface.GetComponent<JumpTracker>();
        InfoUIInterface = FlightInterface.GetComponent<InfoUIInterface>();
        MissionManager = GetComponent<MissionManager>();
        TenKeyPrompt = GetComponent<TenKeyPrompt>();
        CoolDownPanel = FlightInterface.GetComponent<CoolDownPanel>();

        UpdatePanelColors();

        PlayerData.Player.Load(PlayerData.CurrentPlayer);
        GetProblem();
        UpdateDebriefing();

    }

    void UpdateMissionInfoUI()
    {
        MissionParameters CurrentMission = MissionManager.Campaigns[0].Missions[PlayerData.Player.CurrentJump];

        int JumpsRemain = CurrentMission.NumberOfProblems - PlayerData.Player.CurrentJumpProgress;

        InfoUIInterface.UpdateDestination(CurrentMission.DestinationName);
        JumpTracker.DisplayJumps(JumpsRemain);

        InfoUIInterface.UpdateBasicInfo(CurrentMission.BriefingText);
        InfoUIInterface.UpdateDistanceInfo(CurrentMission.DistanceToDestination);
        InfoUIInterface.UpdateConstellationData(CurrentMission.ConstellationInfo);
    }

    void UpdateDebriefing()
    {
        MissionParameters CurrentMission = MissionManager.Campaigns[0].Missions[PlayerData.Player.CurrentJump];

        InfoUIInterface.UpdateDiscoveryText(CurrentMission.DiscoveryInfoText);

        InfoUIInterface.UpdateDebriefingSystem(CurrentMission.DestinationName);

        InfoUIInterface.UpdateSystemData(CurrentMission.SystemDataText);
    }

    void GetProblem()
    {
        MissionParameters CurrentMission = MissionManager.Campaigns[0].Missions[PlayerData.Player.CurrentJump];

        Generator.NewProblem(CurrentMission.operation, CurrentMission.term0Upper, CurrentMission.term0Lower, CurrentMission.term1Upper, CurrentMission.term1Lower);
        OutputOperator.text = Generator.currentProblem.operation;
        OutputTerm1.text = Generator.currentProblem.addend1.ToString();
        OutputTerm2.text = Generator.currentProblem.addend2.ToString();
        UpdateMissionInfoUI();

    }

    void NewMission()
    {
        PlayerData.Player.CurrentJumpProgress = 0;
        if (PlayerData.Player.CurrentJump < MissionManager.Campaigns[0].Missions.Count)
        {
            UpdateDebriefing();
            InfoUIInterface.SetDebriefingPanelActive(true);
            PlayerData.Player.CurrentJump++;
            PlayerData.Player.CurrentJumpProgress = 0;
            PlayerData.Player.Save(PlayerData.CurrentPlayer);
        }
    }

    public void CheckAnswer(int answer)
    {
        PlayerData.Player.LifetimeProblemsAttempted++;
        DisplaySolution();
        DisplayDifference(answer);
        if (Generator.CheckSolution(answer))
        {
            TenKeyPrompt.DisablePanel();
            PlayerData.Player.LifetimeProblemsCorrect++;
            PlayerData.Player.CurrentJumpProgress++;
            if (PlayerData.Player.CurrentJumpProgress == MissionManager.Campaigns[0].Missions[PlayerData.Player.CurrentJump].NumberOfProblems)
            {
                NewMission();
            }
            IlluminateCorrect();
            AddHealth();
        }
        else
        {
            SubtractHealth();
            IlluminateError();
        }
        PlayerData.SavePlayer();
        GetProblem();
    }

    void AddHealth()
    {
        if(lives < 6)
        {
            lives++;
        }
        StabilityPanel.TurnOnIndicator();
        UpdatePanelColors();
    }

    void SubtractHealth()
    {
        lives--;
        StabilityPanel.TurnOffIndicator();
        if(lives <= 0)
        {
            lives = 6;
            CoolDownPanel.StartCoolGame();
        }
        UpdatePanelColors();
    }

    void UpdatePanelColors()
    {
        if (lives > 4) { Panels.ChangePanelColor("ok"); }
        else if (lives <= 4 && lives > 2) { Panels.ChangePanelColor("caution"); }
        else { Panels.ChangePanelColor("critical"); }
    }

    public void IlluminateCorrect()
    {
       StartCoroutine("BlinkCorrect");
    }

    public void IlluminateError()
    {
       StartCoroutine("BlinkError");
    }

    public void DisplaySolution()
    {
        SolutionDisplay.DisplayNewSolution(Generator.currentProblem.addend1, Generator.currentProblem.addend2, Generator.currentProblem.solution);
    }

    public void DisplayDifference(int answer)
    {
        int output = answer - Generator.currentProblem.solution;
        if(output < 0)
        {
            output -= (output*2);
        }
        SolutionDisplay.DisplayDifference(output);
    }

    public IEnumerator BlinkCorrect()
    {
        int blinks = 0;
        while(blinks < 2)
        {
            CorrectLight.SetActive(true);

            yield return new WaitForSeconds(.5f);

            CorrectLight.SetActive(false);

            blinks++;
        }
    }

    public IEnumerator BlinkError()
    {
        int blinks = 0;
        while (blinks < 2)
        {
            ErrorLight.SetActive(true);

            yield return new WaitForSeconds(.5f);

            ErrorLight.SetActive(false);

            blinks++;
        }
    }

}