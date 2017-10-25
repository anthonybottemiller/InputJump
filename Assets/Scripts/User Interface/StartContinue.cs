using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartContinue : MonoBehaviour {

    public Text buttonLabel;
    public PlayerDataManager playerDataManager;
    bool hasPlayed;

	// Use this for initialization
	void Start () {

        hasPlayed = false;

		if(playerDataManager.Player.CurrentJump != 0 || playerDataManager.Player.CurrentJumpProgress != 0)
        {
            buttonLabel.text = "Continue";
            hasPlayed = true;
        }

        else
        {
            buttonLabel.text = "New Game";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void LoadNext()
    {
        if (hasPlayed) { SceneManager.LoadScene("CockpitBMockup"); }
        else { SceneManager.LoadScene("ShipyardProto"); }
    }
}
