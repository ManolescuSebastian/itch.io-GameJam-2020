using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SystemHandler : MonoBehaviour
{

    public static event Action<SystemHandler> onLaunchPressed = delegate { };

    [SerializeField]
    public GameObject panel;

    public void showBuildPanel(bool isVisible)
    {
        panel.SetActive(isVisible);
    }

    public void LaunchRocketActivated()
    {
        onLaunchPressed(this);
    }

}
