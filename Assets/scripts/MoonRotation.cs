using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{

    [SerializeField]
    private Transform rotationCenter;

    [SerializeField]
    private float rotationRadius = 2f;

    [SerializeField]
    private float angularSpeed = 2f;

    private bool randomRadius = false;

    private float posX = 0f;
    private float posY = 0f;
    private float angle = 0f;

    private float rotationDivider = 2;

    void Start()
    {
        if (rotationCenter == null)
        {
           GameObject[] earth = GameObject.FindGameObjectsWithTag("earth");
            if (earth.Length > 0)
            {
                rotationCenter = earth[0].transform;
            }
        }

        if (randomRadius)
        {
            rotationDivider = Random.Range(1.7f, 3f);
        }

    }

    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / rotationDivider;
      
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("transport_rocket")){
            MissionData.Instance.IncreaseMoonLandings();
        }
    }

}
