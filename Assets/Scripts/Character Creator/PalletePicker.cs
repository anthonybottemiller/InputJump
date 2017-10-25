using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalletePicker : MonoBehaviour {
    public List<GameObject> colorButtons;
    public GameObject creator;
    CharacterCreator characterCreator;

    private void Start()
    {
        characterCreator = creator.GetComponent<CharacterCreator>();
    }

    public void changeHead(int button)
    {
        Image renderer = colorButtons[button].GetComponent<Image>();
        characterCreator.colorHead(renderer.color);
    }

    public void changeFace(int button)
    {
        Image renderer = colorButtons[button].GetComponent<Image>();
        characterCreator.colorFace(renderer.color);
    }

    public void changeHair(int button)
    {
        Image renderer = colorButtons[button].GetComponent<Image>();
        characterCreator.colorHair(renderer.color);
    }

    public void changeExtra(int button)
    {
        Image renderer = colorButtons[button].GetComponent<Image>();
        characterCreator.colorExtra(renderer.color);
    }

}
