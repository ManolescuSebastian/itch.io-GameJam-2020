using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RocketBuildManager : MonoBehaviour
{

    [SerializeField]
    List<GameObject> rocketList;
    [SerializeField]
    Transform shuttleLaunchpad;

    private GameObject currentBuildRocket;

    void Start()
    {
        if (rocketList == null)
        {
            rocketList = new List<GameObject>();
        }

        if (shuttleLaunchpad == null)
        {
            shuttleLaunchpad = GetComponent<Transform>();
        }
    }

    public void SelectRocket(int type)
    {
        if (rocketList.Count() <= 0)
        {
            return;
        }

        if (currentBuildRocket != null)
        {
            Destroy(currentBuildRocket);
        }

       GameObject rocket = rocketList[type];
       GameObject rocketObject = Instantiate(rocket, shuttleLaunchpad.position, Quaternion.identity);
       Renderer rocketRenderer = rocketObject.GetComponent<Renderer>();
       rocketObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
       rocketObject.transform.parent = shuttleLaunchpad;

       currentBuildRocket = rocketObject;
    }



    public void AcceptSelectedRocket()
    {
        if (currentBuildRocket == null)
        {
            return;
        }

        Renderer rocketRenderer = currentBuildRocket.GetComponent<Renderer>();
        currentBuildRocket.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

        currentBuildRocket = null;
    }
}
