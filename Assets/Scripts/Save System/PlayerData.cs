using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class PlayerData {

    public String PilotName;
    public int PilotPortrait;

    public int CurrentJump;
    public int CurrentJumpProgress;

    public int CurrentMission;

    public long LifetimeProblemsAttempted;
    public long LifetimeProblemsCorrect;

    public bool HasJumpedAlphaCentauri;

    string Documents;
    string SavePath;

    public SerialColor headColor;
    public SerialColor faceColor;
    public SerialColor hairColor;
    public SerialColor extraColor;

    public string headSetting;
    public string faceSetting;
    public string hairSetting;
    public string extraSetting;


    const float maxLum = 255f;

    public PlayerData()
    {
        Documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        SavePath = Documents + "/InputJump";

        PilotName = "Pilot Unknown";
        PilotPortrait = 0;

        CurrentJump = 0;
        CurrentJumpProgress = 0;

        CurrentMission = 0;

        LifetimeProblemsAttempted = 0;
        LifetimeProblemsCorrect = 0;

        HasJumpedAlphaCentauri = false;

        headColor = new SerialColor();
        faceColor = new SerialColor();
        hairColor = new SerialColor();
        extraColor = new SerialColor();

        headSetting = "Head0";
        faceSetting = "Face0";
        hairSetting = "Hair0";
        extraSetting = "Extra0";
    }

    public void Save(int currentPlayer)
    // Save player data to disk
    {
        Debug.Log("Save Header");
        Debug.Log("Current Player = " + this.PilotName);
        Debug.Log("Saving Player " + currentPlayer.ToString());
        if (!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); };
        //Check If Save directory exists if not create the save directory;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SavePath + "/player" + currentPlayer.ToString() + ".sav");

        PlayerData data = this;
        //Initialize data object to the data in this object instance

        bf.Serialize(file, data);
        //Write the data object to disk

        file.Close();

    }


    public void Load(int currentPlayer)
    // Load Player data from disk
    {
        Debug.Log("Load Header");
        Debug.Log("Current Player = " + this.PilotName);
        Debug.Log("Loading Player " + currentPlayer.ToString());
        // Only execute if the file exists!
        if (File.Exists(Documents + "/InputJump/player" + currentPlayer.ToString()+".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Documents + "/InputJump/player" + currentPlayer.ToString() + ".sav", FileMode.Open);
            // initialize Starship data in memory with data from disk
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            // Assign values to object in memory
            this.PilotName = data.PilotName;
            this.PilotPortrait = data.PilotPortrait;

            this.CurrentJump = data.CurrentJump;
            this.CurrentJumpProgress = data.CurrentJumpProgress;

            this.CurrentMission = data.CurrentMission;

            this.LifetimeProblemsAttempted = data.LifetimeProblemsAttempted;
            this.LifetimeProblemsCorrect = data.LifetimeProblemsCorrect;

            this.HasJumpedAlphaCentauri = data.HasJumpedAlphaCentauri;

            this.headColor = data.headColor;
            this.faceColor = data.faceColor;
            this.hairColor = data.hairColor;
            this.extraColor = data.extraColor;

            this.headSetting = data.headSetting;
            this.faceSetting = data.faceSetting;
            this.hairSetting = data.hairSetting;
            this.extraSetting = data.extraSetting;
        }
    }

}
