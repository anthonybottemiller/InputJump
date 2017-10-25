using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class StarshipData {
    public int hull;
    public int engine;
    public int cockpit;
    public SerialColor hullColor;
    public SerialColor cockpitColor;
    public SerialColor engineColor;
    string Documents;
    string SavePath;

    public StarshipData(int iHull, int iEngine, int iCockpit, SerialColor iHullColor, SerialColor iCockpitColor, SerialColor iEngineColor)
    {
        Documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        SavePath = Documents + "/InputJump";
        this.hull = iHull;
        this.engine = iEngine;
        this.cockpit = iCockpit;
        this.hullColor = iHullColor;
        this.cockpitColor = iCockpitColor;
        this.engineColor = iEngineColor;

    }

    public StarshipData()
    {
        this.hullColor = new SerialColor();
        this.cockpitColor = new SerialColor();
        this.engineColor = new SerialColor();
        Documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        SavePath = Documents + "/InputJump";
        this.hull = 0;
        this.engine = 0;
        this.cockpit = 0;
    }

    public void Save(int player = 0)
    // Save Starship data to disk
    {
        if (!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); };


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SavePath + "/starship" + player.ToString() + ".sav");

        StarshipData data = new StarshipData(hull, engine, cockpit, hullColor, cockpitColor, engineColor);

        bf.Serialize(file, data);
        file.Close();

    }

    public void Load(int player = 0)
    // Load Starship data from disk
    {
        if (!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); };

        // Only execute if the file exists!
        if (File.Exists(SavePath + "/starship" + player.ToString() + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SavePath + "/starship" + player.ToString() + ".sav", FileMode.Open);
            // initialize Starship data in memory with data from disk
            StarshipData data = (StarshipData)bf.Deserialize(file);
            file.Close();
            // Assign values to object in memory
            hull = data.hull;
            engine = data.engine;
            cockpit = data.cockpit;
            hullColor = data.hullColor;
            cockpitColor = data.cockpitColor;
            engineColor = data.engineColor;
        }
    }
}
