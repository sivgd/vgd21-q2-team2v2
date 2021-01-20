using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private float diePoint;
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        diePoint = Time.time + lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > diePoint)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().hit();
            Destroy(gameObject);
        }
    }
}
