using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyLightController : MonoBehaviour {
    public List<GameObject> Buttons;
    public List<Image> ButtonRenderers;
    public Color OnColor;
    public Color OffColor;
    public float BlinkDuration = .2f;


	// Use this for initialization
	void Start ()
    {
        InitRenderers();
    }

    public void IlluminateKey(int Button)
    {
            var Ill = BlinkKey(Button);
            StartCoroutine(Ill);
    }

    IEnumerator BlinkKey(int key)
    {
        ButtonRenderers[key].color = OnColor;

        yield return new WaitForSeconds(BlinkDuration);

        ButtonRenderers[key].color = OffColor;

    }
    void InitRenderers()
    {
            foreach (GameObject Button in Buttons)
            {
            // Get Reference to panels sprite renderer check if null and put it in the renderers list
            Image NewRenderer = Button.GetComponent<Image>();
                if (NewRenderer != null) { ButtonRenderers.Add(NewRenderer); }
            }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
