using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buitre : MonoBehaviour
{
    int direccionHorizontal;
    float alturaInicial, posicionInicial;
    public float velocidadDePatrullaje, distanciaDePatrullaje;
    public float distanciaParaPerseguir;
    bool cambioDireccion;
    public GameObject target;
    SpriteRenderer sr;
    Vector2 vectorPosicionInicial;

    private void Awake()
    {
        alturaInicial = transform.localPosition.y;
        posicionInicial = transform.localPosition.x;
    }
    private void Start()
    {
        
        direccionHorizontal = 1;
        cambioDireccion = true;
        sr = GetComponent<SpriteRenderer>();
        print("X: " + posicionInicial + "  ..... Y:  " + alturaInicial);
    }

    private void Update()
    {
        target = GameObject.Find("Rectangle");
        vectorPosicionInicial  = new Vector2(posicionInicial, alturaInicial);
        if (Patrullando())
        {
            //Patrullar
            transform.Translate(Vector2.right * direccionHorizontal * velocidadDePatrullaje * Time.deltaTime);

            if(distanciaDePatrullaje == 0)
            {
                direccionHorizontal = 0;
            }
            else if (vectorPosicionInicial.x + (-vectorPosicionInicial.x + transform.localPosition.x) > vectorPosicionInicial.x + distanciaDePatrullaje)
            {
                direccionHorizontal = -1;
                sr.flipX = true;
            }
            else if (vectorPosicionInicial.x + (-vectorPosicionInicial.x + transform.localPosition.x) < vectorPosicionInicial.x - distanciaDePatrullaje)
            {
                direccionHorizontal = 1;
                sr.flipX = false;
            }
            //recuperandose
            if (transform.position.y - alturaInicial > 0.075f || transform.position.y - alturaInicial < -0.075f)
            {

                Vector2 destino = Vector2.MoveTowards(transform.position, vectorPosicionInicial, velocidadDePatrullaje * Time.deltaTime);
                transform.position = destino;
                if (destino.x > transform.position.x)
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }
            }

        }
        else
        {
            if (transform.position.x > target.transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            Vector2 nuevaPosicion = Vector2.MoveTowards(transform.position, target.transform.position, velocidadDePatrullaje * Time.deltaTime);
            transform.position = nuevaPosicion;
        }
    }


    public bool Patrullando()
    {

        if(target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < distanciaParaPerseguir)
            {

                Debug.Log("A Distancia para perseguir");
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
        
    }
}
