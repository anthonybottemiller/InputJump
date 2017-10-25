using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgramState : MonoBehaviour {


    public SaveIndex Index;


	// Use this for initialization
	void Start () {
        Index = new SaveIndex();
        Index.Load();
	}

    public void ClickLoad(int player)
    {
        Index.CurrentPlayer = player;
        Debug.Log("Player is switching to");
        Debug.Log(Index.CurrentPlayer);
        Index.Save();

        switch (player)
        {
            case 0:
                if (Index.Save0Populated) { SceneManager.LoadScene("CockpitBMockup"); }
                else { SceneManager.LoadScene("PilotRegistration"); }
                break;
            case 1:
                if (Index.Save1Populated) { SceneManager.LoadScene("CockpitBMockup"); }
                else { SceneManager.LoadScene("PilotRegistration"); }
                break;
            case 2:
                if (Index.Save2Populated) { SceneManager.LoadScene("CockpitBMockup"); }
                else { SceneManager.LoadScene("PilotRegistration"); }
                break;
        }

    }
}
