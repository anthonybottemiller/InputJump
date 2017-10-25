using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour { 

    public int CurrentPlayer;
    public PlayerData Player;
    public ProgramState State;

	// Use this for initialization
	void Start () {
        CurrentPlayer = State.Index.CurrentPlayer;
        Player = new PlayerData();
        LoadPlayer();
	}

    // Update is called once per frame

    public void SavePlayer()
    {
        State.Index.Load();
        Player.Save(State.Index.CurrentPlayer);
    }

    public void LoadPlayer()
    {
        State.Index.Load();
        Player.Load(State.Index.CurrentPlayer);
    }
}