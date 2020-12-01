using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    public GameObject PauseMenu = default;

    [SerializeField]
    public GameObject PauseButton = default;

    [SerializeField]
    public GameObject SettingsPanel;


    public void PauseGame()
    {
        if (PauseMenu == null)
            return;

        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (PauseMenu == null)
            return;

        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettigsPanel(bool state)
    {
        SettingsPanel.SetActive(state);
    }

}
