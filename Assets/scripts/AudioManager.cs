using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    public AudioSource rocketSound;

    [SerializeField]
    public AudioSource backgroundMusic;

    [SerializeField]
    public Toggle backgroundMusicToggle;

    [SerializeField]
    public Toggle soundToggle;

    private bool soundPlayState = true;

    void Awake()
    {
        backgroundMusic.Play();

        backgroundMusicToggle.onValueChanged.AddListener(delegate {
            BackgroundMusic(backgroundMusicToggle.isOn);
        });

        soundToggle.onValueChanged.AddListener(delegate {
            SoundPlayState(soundToggle.isOn);
        });
    }

    void OnEnable()
    {
        EventManager.StartListening("RocketLaunchSound", PlayRocketSound);
    }

    void OnDisable()
    {
        EventManager.StopListening("RocketLaunchSound", PlayRocketSound);
    }

    public void PlayRocketSound()
    {
        if (!soundPlayState) {
            return;
        }
        rocketSound.Play();
    }


    public void BackgroundMusic(bool state)
    {
        if (state)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }
    }

    public void SoundPlayState(bool state)
    {
        soundPlayState = state;
    }

}
