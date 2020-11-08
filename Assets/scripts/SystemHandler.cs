using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemHandler : MonoBehaviour
{

    [SerializeField]
    public GameObject panel;

    public void showBuildPanel(bool isVisible)
    {
        panel.SetActive(isVisible);
    }


}
