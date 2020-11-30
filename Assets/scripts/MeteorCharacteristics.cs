using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorCharacteristics : MonoBehaviour
{

    enum METEOR { URANIUM, TELLERIUM, COMBINED };

    private METEOR meteorType;

    [SerializeField]
    public float speed;

    [SerializeField]
    public List<Sprite> meteorSprites;

    private int meteorValue;

    void Awake()
    {
        EventManager.TriggerEvent("VerifyGameState", 1);
    }

    void Start()
    {
        if (meteorSprites.Count > 0)
        {
            transform.GetComponent<SpriteRenderer>().sprite = meteorSprites[Random.Range(0, meteorSprites.Count -1)];
        }       

        speed = Random.Range(0.9f, 1.9f);
        transform.localScale = Vector2.one * Random.Range(0.05f, 0.2f);

        float randomColorValueGenerate = Random.value;
        if (randomColorValueGenerate <= 0.45)
        {
            meteorType = METEOR.URANIUM;
            this.GetComponent<SpriteRenderer>().color = new Color32(50, 235, 120, 255);
        }
        else if(randomColorValueGenerate >= 0.45 && randomColorValueGenerate <= 0.9)
        {
            meteorType = METEOR.TELLERIUM;
            this.GetComponent<SpriteRenderer>().color = new Color32(253, 137, 50, 225);
        }
        else if(randomColorValueGenerate >= 0.90 && randomColorValueGenerate <= 1)
        {
            meteorType = METEOR.COMBINED;
            this.GetComponent<SpriteRenderer>().color = new Color32(147, 152, 253, 255);
        }

        meteorValue = RoundUp((int)((transform.localScale.x + transform.localScale.y) * 100)) * 3;
    }

    int RoundUp(int value)
    {
        return (value + 4) / 5 * 5;
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

        if (collision.collider.CompareTag("resources_rocket")) { 
            switch (meteorType){
                case METEOR.URANIUM:
                    EventManager.TriggerEvent("IncreaseUraniumScore", meteorValue);
                    break;

                case METEOR.TELLERIUM:
                    EventManager.TriggerEvent("IncreaseTelleriumScore", meteorValue);
                    break;

                case METEOR.COMBINED:
                    EventManager.TriggerEvent("IncreaseUraniumScore", meteorValue);
                    EventManager.TriggerEvent("IncreaseTelleriumScore", meteorValue);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
