using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpanner : MonoBehaviour
{
    [SerializeField]
    GameObject meteorite;

    void Start()
    {
        if (meteorite == null)
            meteorite = new GameObject();

        StartCoroutine(MeteoriteSpawner());
    }

    IEnumerator MeteoriteSpawner()
    {
        Vector2 trasformRand = new Vector2(transform.position.x, transform.position.y + Random.Range(-1f, 1.5f));
        while (true)
        {
            GameObject meteoriteInstance = Instantiate(meteorite, trasformRand, Quaternion.identity);
            meteoriteInstance.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(Random.Range(1, 7));
        }
    }


}
