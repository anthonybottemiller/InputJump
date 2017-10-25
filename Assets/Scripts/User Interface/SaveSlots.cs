using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlots : MonoBehaviour {

    public Text SaveLabel0;
    public Text SaveLabel1;
    public Text SaveLabel2;

    public ProgramState State;

    public void Start()
    {
        SaveLabel0.text = State.Index.Player0;
        SaveLabel1.text = State.Index.Player1;
        SaveLabel2.text = State.Index.Player2;
    }
}
