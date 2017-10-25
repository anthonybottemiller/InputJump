using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownPanel : MonoBehaviour {

    public GameObject panel;

    public Text scoreOutput;

    public int lineScore;

    public GameObject coolGame;

	// Use this for initialization
	void Start () {
        InitLineScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitLineScore()
    {
        lineScore = 0;
        UpdateScoreDisplay();
    }

    public void IncreaseScore()
    {
        lineScore++;
        UpdateScoreDisplay();
        if (lineScore == 5) { StopCoolGame(); }
    }

    public void UpdateScoreDisplay()
    {
        scoreOutput.text = lineScore.ToString();
    }

    public void StartCoolGame()
    {
        Instantiate(coolGame, new Vector3(-200f,-500f,0f), Quaternion.identity);
        InitLineScore();
        panel.SetActive(true);
    }

    public void StopCoolGame()
    {
        ResetStability();
        GameObject gameInstance = GameObject.Find("TetrisGame(Clone)");
        Destroy(gameInstance);
        panel.SetActive(false);
    }

    public void ResetStability()
    {
        StabilityPanel stablePanel = gameObject.GetComponentInParent<StabilityPanel>();
        stablePanel.ResetStability();
    }
}
