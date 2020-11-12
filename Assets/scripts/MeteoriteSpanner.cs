using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpanner : MonoBehaviour
{
    [SerializeField]
    GameObject meteorite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MeteoriteSpawner());
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    IEnumerator MeteoriteSpawner()
    {
        while (true)
        {
            GameObject meteoriteInstance = Instantiate(meteorite, transform.position, Quaternion.identity);
            meteoriteInstance.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(7);
        }
    }
}
