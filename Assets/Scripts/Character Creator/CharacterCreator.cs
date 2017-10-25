using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour {

    public GameObject head;
    public GameObject face;
    public GameObject hair;
    public GameObject extra;

    public PlayerDataManager PlayerDataManager;



    const string path = "CharacterCreator/";

    // Use this for initialization
    void Start () {

        initFromMemory();

	}

    public void initFromMemory()
    {
        ChangeHead(PlayerDataManager.Player.headSetting);
        colorHead(PlayerDataManager.Player.headColor.ToUColor());

        ChangeFace(PlayerDataManager.Player.faceSetting);
        colorFace(PlayerDataManager.Player.faceColor.ToUColor());

        ChangeHair(PlayerDataManager.Player.hairSetting);
        colorHair(PlayerDataManager.Player.hairColor.ToUColor());

        ChangeExtra(PlayerDataManager.Player.extraSetting);
        colorExtra(PlayerDataManager.Player.extraColor.ToUColor());
    }

    public void ChangeHead(string newHead)
    {
        PlayerDataManager.Player.headSetting = newHead;
        changeSprite(head, "Heads/" + newHead);
    }

    public void ChangeFace(string newFace)
    {
        PlayerDataManager.Player.faceSetting = newFace;
        changeSprite(face, "Faces/" + newFace);
    }

    public void ChangeHair(string newHair)
    {
        PlayerDataManager.Player.hairSetting = newHair;
        changeSprite(hair, "Hair/" + newHair);
    }

    public void ChangeExtra(string newExtra)
    {
        PlayerDataManager.Player.extraSetting = newExtra;
        changeSprite(extra, "Extras/" + newExtra);
    }

    public void colorHead(Color newColor)
    {
        PlayerDataManager.Player.headColor = SerialColor.ColorToSColor(newColor);
        changeSpriteColor(head, newColor);
    }

    public void colorFace(Color newColor)
    {
        PlayerDataManager.Player.faceColor = SerialColor.ColorToSColor(newColor);
        changeSpriteColor(face, newColor);
    }

    public void colorHair(Color newColor)
    {
        PlayerDataManager.Player.hairColor = SerialColor.ColorToSColor(newColor);
        changeSpriteColor(hair, newColor);
    }

    public void colorExtra(Color newColor)
    {
        PlayerDataManager.Player.extraColor = SerialColor.ColorToSColor(newColor);
        changeSpriteColor(extra, newColor);
    }


    void changeSprite(GameObject gameObject, string newSprite)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Sprite foundSprite = Resources.Load<Sprite>(path + newSprite);
        if(foundSprite != null) { spriteRenderer.sprite = foundSprite; }
        else { Debug.LogError("Error!!!! **" + path + newSprite + "** sprite not found!!!"); }
        
    }

    void changeSpriteColor(GameObject gameObject, Color newColor)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = newColor;
    }


}
