using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed;
    public float speedMultiplier = 0.1f;
    private Rigidbody2D rb2d;
    private bool shuttleStart = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shuttleStart) {
            speed += speedMultiplier;
            rb2d.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
     }

    public void isShuttleStart(bool isEngaged)
    {
        shuttleStart = isEngaged;
    }
}
