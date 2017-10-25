using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenKeyPrompt : MonoBehaviour {

    public PlayerDataManager PlayerDataManager;

    public GameObject instructionPanel;

	// Use this for initialization
	void Start () {
        if(PlayerDataManager.Player.CurrentJump == 0 && PlayerDataManager.Player.CurrentJumpProgress == 0) { instructionPanel.SetActive(true); }
	}
	
    public void DisablePanel()
    {
        instructionPanel.SetActive(false);
    }
}
