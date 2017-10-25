using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarshipCreator : MonoBehaviour {

    public Image hullObject;
    public Image cockpitObject;
    public Image engineObject;

    public List<Sprite> Hulls;
    public List<Sprite> Cockpits;
    public List<Sprite> Engines;

    int hull;
    int cockpit;
    int engine;

    GameObject CurrentShip;

	// Use this for initialization
	void Start () {
		if(Hulls.Count == 0)
        {
            Debug.LogError("No hulls are configured!");
        }
        if (!(Cockpits.Count > 0))
        {
            Debug.LogError("No cockpits are configured!");
        }
        if (!(Engines.Count > 0))
        {
            Debug.LogError("No engines are configured!");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}


    void AdvanceHull()
    {
        if(hull < Hulls.Count -1)
        {
            hull++;
            hullObject.sprite = Hulls[hull];
        }
        else
        {
            hull = 0;
            hullObject.sprite = Hulls[hull];
        }
    }


    void AdvanceEngine()
    {
        if (engine < Engines.Count - 1)
        {
            engine++;
            engineObject.sprite = Engines[engine];
        }
        else
        {
            engine = 0;
            engineObject.sprite = Engines[engine];
        }
    }

    void AdvanceCockpit()
    {
        if (cockpit < Cockpits.Count - 1)
        {
            cockpit++;
            hullObject.sprite = Cockpits[cockpit];
        }
        else
        {
            cockpit = 0;
            hullObject.sprite = Hulls[cockpit];
        }
    }

}


