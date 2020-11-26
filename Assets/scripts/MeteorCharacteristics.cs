using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorCharacteristics : MonoBehaviour
{

    enum METEOR { URANIUM, TELLERIUM };

    private METEOR meteorType;

    [SerializeField]
    public float speed;

    [SerializeField]
    public List<Sprite> meteorSprites;

    public int meteorValue;

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
            meteorType = METEOR.URANIUM;
            this.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.9f, 0.1f, 1f);
        }
        else
        {
            meteorType = METEOR.TELLERIUM;
            this.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.5f, 0.1f, 1f);
        }

        meteorValue = roundUp((int)((transform.localScale.x + transform.localScale.y) * 100)) * 3;
    }

    int roundUp(int n)
    {
        return (n + 4) / 5 * 5;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
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

        if (meteorType.Equals(METEOR.URANIUM))
        {
            EventManager.TriggerEvent("IncreaseUraniumScore", meteorValue);
        }

        if (meteorType.Equals(METEOR.TELLERIUM))
        {
            EventManager.TriggerEvent("IncreaseTelleriumScore", meteorValue);
        }
    }
}
