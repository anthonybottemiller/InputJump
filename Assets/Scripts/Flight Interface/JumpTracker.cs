using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpTracker : MonoBehaviour {

    public Text JumpDisplay;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DisplayJumps(int jmps)
    {
        JumpDisplay.text = jmps.ToString();
    }
}
