using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveIndex
{
    string Documents;
    string SavePath;

    public bool Save0Populated;
    public bool Save1Populated;
    public bool Save2Populated;

    public string Player0;
    public string Player1;
    public string Player2;

    public int CurrentPlayer;

    public SaveIndex()
    {
        Documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        SavePath = Documents + "/InputJump";


        string DefaultName = "Unknown Pilot";

        Save0Populated = false;
        Save1Populated = false;
        Save2Populated = false;

        Player0 = DefaultName;
        Player1 = DefaultName;
        Player2 = DefaultName;
    }

    public void Save()
    // Save index data to disk
    {
        if (!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); };
        //Check If Save directory exists if not create the save directory;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SavePath + "/SaveIndex.sav");

        SaveIndex data = this;
        //Initialize data object to the data in this object instance

        bf.Serialize(file, data);
        //Write the data object to disk

        file.Close();

    }

    public void Load()
    // Load Index data from disk
    {
        // Only execute if the file exists!
        if (File.Exists(SavePath + "/SaveIndex.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SavePath + "/SaveIndex.sav", FileMode.Open);
            // initialize Starship data in memory with data from disk
            SaveIndex data = (SaveIndex)bf.Deserialize(file);
            file.Close();

            // Assign values to object in memory
            this.Save0Populated = data.Save0Populated;
            this.Save1Populated = data.Save1Populated;
            this.Save2Populated = data.Save2Populated;

            this.Player0 = data.Player0;
            this.Player1 = data.Player1;
            this.Player2 = data.Player2;

            this.CurrentPlayer = data.CurrentPlayer;
        }
    }

}
