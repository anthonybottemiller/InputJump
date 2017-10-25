using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRegistration : MonoBehaviour {

    public PlayerDataManager PlayerManager;
    public Text Input;
    public ProgramState State;

    public void Register()
    {
        switch(State.Index.CurrentPlayer)
        {
            case 0:
                State.Index.Player0 = Input.text;
                State.Index.Save0Populated = true;
                break;
            case 1:
                State.Index.Player1 = Input.text;
                State.Index.Save1Populated = true;
                break;
            case 2:
                State.Index.Player2 = Input.text;
                State.Index.Save2Populated = true;
                break;
            default:
                Debug.Log("Its been falling through");
                break;
        }
        State.Index.Save();
        Debug.Log(PlayerManager.Player.PilotName);
        PlayerManager.Player.PilotName = Input.text;
        Debug.Log(PlayerManager.Player.PilotName);
        PlayerManager.SavePlayer();
        SceneManager.LoadScene("ShipyardProto");
    }

}
