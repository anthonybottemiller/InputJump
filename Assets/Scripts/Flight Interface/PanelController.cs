using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
    public int ColorDefault;
    public List<GameObject> Panels;
    public List<Image> PanelRenderers;

    public Color OkCondition;
    public Color CautionCondition;
    public Color CriticalCondition;

	// Use this for initialization
	void Start () {
		foreach(GameObject Panel in Panels)
        {
            // Get Reference to panels sprite renderer check if null and put it in the renderers list
            Image NewRenderer = Panel.GetComponent<Image>();
            if (NewRenderer != null) { PanelRenderers.Add(NewRenderer); }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void ChangePanelColor(string condition)
    {
        Color currentCondition;
        switch(condition)
        {
            case "ok":
                currentCondition = OkCondition;
                break;
            case "caution":
                currentCondition = CautionCondition;
                break;
            case "critical":
                currentCondition = CriticalCondition;
                break;
            default:
                currentCondition = CriticalCondition;
                break;
        }

        foreach (Image Renderer in PanelRenderers)
        {
            Renderer.color = currentCondition;
        }
    }
    
}
