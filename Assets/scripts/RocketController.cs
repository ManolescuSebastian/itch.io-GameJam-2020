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
    public ParticleSystem flameParticleSystem;

    private Transform resourceDropPosition;
    private bool returnToBase = false;


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
        //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
    }

    public void CheckShuttleStart(bool isEngaged)
    {
        shuttleStart = isEngaged;
    }

    public void ShowFlameParticles()
    {
        if (flameParticleSystem == null)
        {
            return;
        }

        flameParticleSystem?.Play();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("meteorite"))
        {
            MeteorCharacteristics meteorResouceValue = collision.gameObject.GetComponent<MeteorCharacteristics>();

            resourceDropPosition = GameObject.FindGameObjectWithTag("resource_factory").transform;
            speed = 0.5f;
            maxSpeed = 1f;
            smoothTime = 1f;
            returnToBase = true;
        }

        if (collision.collider.CompareTag("resource_factory"))
        {
            Destroy(gameObject);
        }
    }

    void OnDisable()
    {
        SystemHandler.onLaunchPressed -= DepolyShuttle;
    }
}
