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
        return MissionThreeCompleted;
    }

    void OnDestroy() {
        if (this == instance) {
            instance = null;
        }
    }
}