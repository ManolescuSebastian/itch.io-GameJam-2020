using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    public AudioSource rocketSound;

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
        rocketSound.Play();
    }
}
