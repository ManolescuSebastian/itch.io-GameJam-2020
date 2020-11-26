using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    public GameObject PauseMenu = default;

    [SerializeField]
    public GameObject PauseButton = default;


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

}
