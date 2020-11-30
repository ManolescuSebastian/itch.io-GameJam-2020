using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowControl : MonoBehaviour
{
    [SerializeField]
    public GameObject GameOverUI;

    [SerializeField]
    public GameObject RocketContainer;

    void OnEnable()
    {
        EventManager.StartListening("VerifyGameState", VerifyGameState);
    }

    void OnDisable()
    {
        EventManager.StopListening("VerifyGameState", VerifyGameState);
    }

    private void VerifyGameState(int value)
    {
        if ((ScoreManager.UrnaiumScore < 50 || ScoreManager.TelleriumScore < 30) && RocketContainer.transform.childCount <= 0)
        {
            GameOverUI.SetActive(true);
        }
    }
}
