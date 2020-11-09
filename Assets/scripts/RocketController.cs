using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float maxSpeed = 1f;
    [SerializeField]
    public float smoothTime = 3f;
    private bool shuttleStart = false;

    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private ParticleSystem flameParticleSystem;


    void Start()
    {
        if (rb2d != null)
        {
            return;
        }
        rb2d = GetComponent<Rigidbody2D>();
        //flameParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (shuttleStart)
        {
            speed = Mathf.Lerp(speed, maxSpeed, smoothTime);
            rb2d.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void isShuttleStart(bool isEngaged)
    {
        shuttleStart = isEngaged;
    }

    public void showFlameParticles()
    {
        flameParticleSystem.Play();
    }
}
