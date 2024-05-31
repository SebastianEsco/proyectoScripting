using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeDeCuracion : MonoBehaviour
{
    GameObject target;
    Vector2 destino;
    public float velocidad;

    private void Start()
    {
        target = GameObject.Find("Boss");
    }

    private void Update()
    {
        destino = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * velocidad);
        transform.position = destino;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Rectangle")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Boss")
        {
            collision.gameObject.GetComponent<Health>().GetHealth(10,gameObject);
            Destroy(gameObject);
        }
    }
}
