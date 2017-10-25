using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour {

    public float DelayForSeconds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Quit ()
    {
        StartCoroutine("DelayThenQuit");
        
    }

    IEnumerator DelayThenQuit()
    {
        yield return new WaitForSeconds(DelayForSeconds);
        Application.Quit();
    }
}
