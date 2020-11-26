using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public GameObject uraniumScore;
    [SerializeField]
    public GameObject telleriumScore;
    [SerializeField]
    public GameObject uraniumSlider;
    [SerializeField]
    public GameObject telleriumSlider;

    public static int UrnaiumScore;
    public static int TelleriumScore;

    void Awake()
    {
        DefaultScore();

        uraniumSlider.GetComponent<Slider>().minValue = 0;
        uraniumSlider.GetComponent<Slider>().maxValue = 1000;

        telleriumSlider.GetComponent<Slider>().minValue = 0;
        telleriumSlider.GetComponent<Slider>().maxValue = 1000;

        uraniumSlider.GetComponent<Slider>().value = UrnaiumScore;
        telleriumSlider.GetComponent<Slider>().value = TelleriumScore;

        TextMeshProUGUI uraniumScoreText = uraniumScore.GetComponent<TextMeshProUGUI>();
        uraniumScoreText.SetText(UrnaiumScore.ToString());

        TextMeshProUGUI telleriumScoreText = telleriumScore.GetComponent<TextMeshProUGUI>();
        telleriumScoreText.SetText(TelleriumScore.ToString());
    }

    void OnEnable()
    {
        EventManager.StartListening("IncreaseUraniumScore", OnUraniumScoreUpdate);
        EventManager.StartListening("IncreaseTelleriumScore", OnTelleriumScoreUpdate);
    }

    void OnDisable()
    {
        EventManager.StopListening("IncreaseUraniumScore", OnUraniumScoreUpdate);
        EventManager.StopListening("IncreaseTelleriumScore", OnTelleriumScoreUpdate);
    }

    public void DefaultScore()
    {
        UrnaiumScore = 350;
        TelleriumScore = 200;
    }

    public void OnUraniumScoreUpdate(int value)
    {
        UrnaiumScore += value;
        TextMeshProUGUI uraniumScoreText = uraniumScore.GetComponent<TextMeshProUGUI>();
        uraniumScoreText.SetText(UrnaiumScore.ToString());

        uraniumSlider.GetComponent<Slider>().value = UrnaiumScore;
    }

    public void OnTelleriumScoreUpdate(int value)
    {
        TelleriumScore += value;
        TextMeshProUGUI telleriumScoreText = telleriumScore.GetComponent<TextMeshProUGUI>();
        telleriumScoreText.SetText(TelleriumScore.ToString());

        telleriumSlider.GetComponent<Slider>().value = TelleriumScore;
    }

}
