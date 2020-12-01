using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed = 1f;
    [SerializeField]
    private float smoothTime = 3f;
    private bool shuttleStart = false;
    private float rotationSpeed = 2f;

    [SerializeField]
    public ParticleSystem FlameParticleSystem;

    private Transform resourceDropPosition;
    private bool returnToBase = false;

    public ROCKET typeOfRocket;

    void Awake()
    {
        SystemHandler.onLaunchPressed += DepolyShuttle;
    }

    void Update()
    {
        if (shuttleStart)
        {
            if (returnToBase)
            {
                RotateTowards(resourceDropPosition.position);
                speed = Mathf.Lerp(speed, maxSpeed, smoothTime);
                MoveTowards(resourceDropPosition.position);
            }
            else
            {
                speed = Mathf.Lerp(speed, maxSpeed, smoothTime);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void DepolyShuttle(SystemHandler systemHandler)
    {
        shuttleStart = true;
        ShowFlameParticles();

        EventManager.TriggerEvent("RocketLaunchSound");
    }

    public void CheckShuttleStart(bool isEngaged)
    {
        shuttleStart = isEngaged;
    }

    public void ShowFlameParticles()
    {
        if (FlameParticleSystem == null)
        {
            return;
        }

        FlameParticleSystem?.Play();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (typeOfRocket.Equals(ROCKET.RESOURCES))
        {
            if (collision.collider.CompareTag("meteorite"))
            {
                resourceDropPosition = GameObject.FindGameObjectWithTag("resource_factory").transform;
                speed = 0.5f;
                maxSpeed = 1f;
                smoothTime = 1f;
                returnToBase = true;
            }
            else if(collision.collider.CompareTag("moon"))
            {
                Destroy(gameObject);
            }
        } else if (typeOfRocket.Equals(ROCKET.TRANSPORTER))
        {
            if (collision.collider.CompareTag("moon")) {
                //todo add transporter rocket animation
                Destroy(gameObject);
            }
        }

        if (collision.collider.CompareTag("resource_factory"))
        {
            Destroy(gameObject);
        }

        EventManager.TriggerEvent("VerifyGameState");
    }

    void OnDisable()
    {
        SystemHandler.onLaunchPressed -= DepolyShuttle;
    }
}
