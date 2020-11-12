using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    [SerializeField]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.1f, 1.9f);
        transform.localScale =  Vector2.one * Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Meteor collision detected");
        Destroy(gameObject);
    }
}
