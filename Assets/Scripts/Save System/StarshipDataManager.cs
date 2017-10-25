using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipDataManager : MonoBehaviour {
    public HullManager HM;
    public CockpitManager CM;
    public EngineManager EM;
    public StarshipData data = new StarshipData();

    public ProgramState ProgramState;

    // Use this for initialization
    void Start () {

        data.Load(ProgramState.Index.CurrentPlayer);
	}

    public void LoadShip()
    {
        data.Load(ProgramState.Index.CurrentPlayer);
    }

    public void SaveShip()
    {
        data.Save(ProgramState.Index.CurrentPlayer);
    }
}
