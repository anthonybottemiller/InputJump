using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MissionManager : MonoBehaviour {

    public List<Campaign> Campaigns;


    void Start()
    {
        Campaigns = new List<Campaign>();
        Campaign additionCampaign = new Campaign();

        FileStream file = new FileStream(Application.dataPath + "/StreamingAssets/Campaigns/Addition.cam", FileMode.Open);

        additionCampaign.Load(file);
        Campaigns.Add(additionCampaign);
    }
}
