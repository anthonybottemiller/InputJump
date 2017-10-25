using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightController : MonoBehaviour {
    
    public int CharacterLimit = 2;
    int CharsEntered = 0;
    string input = "";
    public Text InputDisplay;
    public GameMaster GM;


    public UIBeeper Beeper;

    KeyLightController Keylights;

	// Use this for initialization
	void Start () {
        Keylights = GetComponent<KeyLightController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(0);
            NewChar("0");
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(1);
            NewChar("1");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(2);
            NewChar("2");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(3);
            NewChar("3");
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(4);
            NewChar("4");
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(5);
            NewChar("5");
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(6);
            NewChar("6");
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(7);
            NewChar("7");
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(8);
            NewChar("8");
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Beeper.Beep();
            Keylights.IlluminateKey(9);
            NewChar("9");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Beeper.Beep();
            GM.CheckAnswer(ProcessInput());
            Reinitialize();
        }


    }

    int ProcessInput()
    {
        if(input == "")
        {
            return 0;
        }
        int output = int.Parse(input);
        return output;
    }

    void Reinitialize()
    {
        CharsEntered = 0;
        input = "";
        InputDisplay.text = "?";
    }

    void NewChar(string newChar)
    {
        if(CharsEntered<CharacterLimit)
        {
            CharsEntered++;
            input += newChar;
            InputDisplay.text = input;
        }
    }

}
