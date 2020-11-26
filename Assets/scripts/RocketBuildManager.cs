using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

enum ROCKET { TRANSPORTER, RESOURCES, DEFENCE, NONE }

public class RocketBuildManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> rocketList;

    [SerializeField]
    Transform shuttleLaunchpad;

    private ROCKET rocketType = ROCKET.NONE;

    private GameObject currentBuildRocket;

    void Start()
    {
        if (rocketList == null)
            rocketList = new List<GameObject>();

        if (shuttleLaunchpad == null)
            shuttleLaunchpad = GetComponent<Transform>();
    }

    public void SelectRocket(int type)
    {
        if (rocketList.Count() <= 0)
            return;

        if (currentBuildRocket != null)
            Destroy(currentBuildRocket);

       GameObject rocket = rocketList[type];
       GameObject rocketObject = Instantiate(rocket, shuttleLaunchpad.position, Quaternion.identity);
       rocketObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
       rocketObject.transform.parent = shuttleLaunchpad;

       currentBuildRocket = rocketObject;

       rocketType = (ROCKET)type;
    }

    public void AcceptSelectedRocket()
    {
        if (currentBuildRocket == null)
            return;

        currentBuildRocket.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        PurchaseValue(rocketType);
        currentBuildRocket = null;
    }


    private void PurchaseValue(ROCKET rocket)
    {
        switch (rocket)
        {
           case ROCKET.TRANSPORTER:
                EventManager.TriggerEvent("IncreaseUraniumScore", -150);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -100);
                break;

            case ROCKET.RESOURCES:
                EventManager.TriggerEvent("IncreaseUraniumScore", -50);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -20);
                break;

            case ROCKET.DEFENCE:
                EventManager.TriggerEvent("IncreaseUraniumScore", -80);
                EventManager.TriggerEvent("IncreaseTelleriumScore", -50);
                break;

            default:
                // do nothing at the moment
                break;
        }

    }
}
