using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorCharacteristics : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    public float rotationSpeed = 30;

    [SerializeField]
    public List<Sprite> meteorSprites;

    public int meteorValue;

    // Start is called before the first frame update
    void Start()
    {

        if (meteorSprites.Count > 0)
        {
            transform.GetComponent<SpriteRenderer>().sprite = meteorSprites[Random.Range(0, meteorSprites.Count -1)];
        }       

        speed = Random.Range(0.9f, 1.9f);
        transform.localScale = Vector2.one * Random.Range(0.05f, 0.2f);
        if (Random.value >= 0.5)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.9f, 0.1f, 1f);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.9f, 1f);
        }

        meteorValue = (int)((transform.localScale.x + transform.localScale.y) * 100);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("resources_rocket"))
        {
            Destroy(gameObject);
        }
    }
}
