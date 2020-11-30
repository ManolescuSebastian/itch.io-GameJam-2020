using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    [SerializeField]
    public GameObject missionPanel;

    [SerializeField]
    public List<GameObject> missionList;

    void Awake()
    {
        if (missionList != null || missionList.Count > 0)
        {
            return;
        }
        missionList = new List<GameObject>();
    }

    public void ShowMissionPanel()
    {
        missionPanel.SetActive(true);
    }

    public void HideMissionPanel()
    {
        missionPanel.SetActive(false);
    }

    public void MissionDisplayListStatus()
    {
        missionList[0].GetComponent<Toggle>().isOn = MissionData.Instance.MissionOneStatusData();
        missionList[1].GetComponent<Toggle>().isOn = MissionData.Instance.MissionTwoStatusData();
        missionList[1].GetComponent<Toggle>().isOn = MissionData.Instance.MissionThreeStatusData();
    }
}
