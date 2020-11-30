using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public enum ROCKET { TRANSPORTER, RESOURCES, DEFENCE, NONE }

public class RocketBuildManager : MonoBehaviour
{
    //transporter purchase values
    private const int TRANSPORTER_URANIUM_PURCHASE = 500;
    private const int TRANSPORTER_TELLERIUM_PURCHASE = 300;

    //resource collector purchase values
    private const int RESOURCES_URANIUM_PURCHASE = 50;
    private const int RESOURCES_TELLERIUM_PURCHASE = 40;

    //defender purchase values
    private const int DEFENCE_URANIUM_PURCHASE = 100;
    private const int DEFENCE_TELLERIUM_PURCHASE = 50;

    [SerializeField]
    List<GameObject> availableRockets;

    [SerializeField]
    Transform shuttleLaunchpad;
    [SerializeField]
    public Button TransporterRocketButton;
    [SerializeField]
    public Button ResourceRocketButton;

    private ROCKET rocketType = ROCKET.NONE;

    private GameObject currentBuildRocket;

    void Start()
    {
        if (availableRockets == null)
            availableRockets = new List<GameObject>();

        if (shuttleLaunchpad == null)
            shuttleLaunchpad = GetComponent<Transform>();
    }

    public void VerifyBuildResources()
    {
        if (ScoreManager.UrnaiumScore < TRANSPORTER_URANIUM_PURCHASE || ScoreManager.TelleriumScore < TRANSPORTER_TELLERIUM_PURCHASE)
        {
            TransporterRocketButton.GetComponent<Image>().color = new Color32(216, 216, 216, 255);
            TransporterRocketButton.enabled = false;
        }
        else{
            TransporterRocketButton.GetComponent<Image>().color = new Color32(80, 207, 122, 255);
            TransporterRocketButton.enabled = true;
        }

        if (ScoreManager.UrnaiumScore < RESOURCES_URANIUM_PURCHASE || ScoreManager.TelleriumScore < RESOURCES_TELLERIUM_PURCHASE)
        {
            ResourceRocketButton.GetComponent<Image>().color = new Color32(216, 216, 216, 255);
            ResourceRocketButton.enabled = false;
        }
        else
        {
            ResourceRocketButton.GetComponent<Image>().color = new Color32(80, 207, 122, 255);
            ResourceRocketButton.enabled = true;
        }

    }

    public void SelectRocket(int type)
    {
        if (availableRockets.Count() <= 0)
            return;

        if (currentBuildRocket != null)
            Destroy(currentBuildRocket);

       GameObject rocket = availableRockets[type];
       GameObject rocketObject = Instantiate(rocket, shuttleLaunchpad.position, Quaternion.identity);
       rocketObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
       rocketObject.transform.parent = shuttleLaunchpad;

       rocketType = (ROCKET)type;
       rocketObject.GetComponent<RocketController>().typeOfRocket = rocketType;

       currentBuildRocket = rocketObject;
    }

    public void AcceptSelectedRocket()
    {
        if (currentBuildRocket == null)
            return;

        currentBuildRocket.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        PurchaseRocket(rocketType);
        currentBuildRocket = null;
    }

    private void PurchaseRocket(ROCKET rocket)
    {
        switch (rocket)
        {
           case ROCKET.TRANSPORTER:
                EventManager.TriggerEvent("IncreaseUraniumScore", -TRANSPORTER_URANIUM_PURCHASE);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -TRANSPORTER_TELLERIUM_PURCHASE);
                MissionData.Instance.MissionTwoStatusData(true);
                break;

            case ROCKET.RESOURCES:
                EventManager.TriggerEvent("IncreaseUraniumScore", -RESOURCES_URANIUM_PURCHASE);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -RESOURCES_TELLERIUM_PURCHASE);
                break;

            case ROCKET.DEFENCE:
                EventManager.TriggerEvent("IncreaseUraniumScore", -DEFENCE_URANIUM_PURCHASE);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -DEFENCE_TELLERIUM_PURCHASE);
                break;

            default:
                // do nothing at the moment
                break;
        }

    }
}
