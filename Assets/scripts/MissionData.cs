using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionData : MonoBehaviour
{
    private static MissionData instance;

    public static MissionData Instance { get { return instance; } }

    private bool MissionOneCompleted;
    private bool MissionTwoCompleted;
    private bool MissionThreeCompleted;
    private bool MissionFourCompleted;
    private bool MissionFiveCompleted;

    private int moonLandingsCount = 0;
    private int specialMeteorCollectCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public bool MissionOneStatusData()
    {
        if (ScoreManager.UrnaiumScore >= 1000 && ScoreManager.TelleriumScore >= 800)
        {
            MissionOneCompleted = true;
        }
        return MissionOneCompleted; 
    }

    public void MissionTwoStatusData(bool status)
    {
        MissionTwoCompleted = status;
    }

    public bool MissionTwoStatusData()
    {
        return MissionTwoCompleted;
    }

    public bool MissionThreeStatusData()
    {
        if(ScoreManager.TelleriumScore >= 1000)
        {
            MissionThreeCompleted = true;
        }

        return MissionThreeCompleted;
    }

    public bool MissionFourStatusData()
    {
        if (specialMeteorCollectCount >= 10)
        {
            MissionFourCompleted = true;
        }
        return MissionFourCompleted;
    }

    public bool MissionFiveStatusData()
    {
        if (moonLandingsCount >= 1) {
            MissionFiveCompleted = true;
        }
        return MissionFiveCompleted;
    }

    public void IncreaseMoonLandings()
    {
        moonLandingsCount++;
    }

    void OnDestroy() {
        if (this == instance) {
            instance = null;
        }
    }
}