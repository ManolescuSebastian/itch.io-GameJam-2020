using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f;

    [SerializeField]
    float angularSpeed = 2f;

    private float posX = 0f;
    private float posY = 0f;
    private float angle = 0f;

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
        
    }



    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius/2;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
