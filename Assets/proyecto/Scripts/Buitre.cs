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

    private void Start()
    {
        alturaInicial = transform.position.y;
        posicionInicial = transform.position.x;
        direccionHorizontal = 1;
        cambioDireccion = true;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        

        if(Patrullando())
        {
            //recuperandose
            if (transform.position.y - alturaInicial > 0.5f || transform.position.y - alturaInicial < -0.5f)
            {
                Vector2 vectorPosicionInicial = new Vector2(posicionInicial, alturaInicial);
                Vector2 destino = Vector2.MoveTowards(transform.position, vectorPosicionInicial, velocidadDePatrullaje * Time.deltaTime);
                transform.position = destino;
                if(destino.x > transform.position.x)
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }
            }
            else
            {
                //Patrullar
                transform.Translate(Vector2.right * direccionHorizontal * velocidadDePatrullaje * Time.deltaTime);


                if (posicionInicial + transform.position.x > posicionInicial + distanciaDePatrullaje)
                {
                    direccionHorizontal = -1;
                    sr.flipX = true;
                }
                else if (posicionInicial + transform.position.x < posicionInicial - distanciaDePatrullaje)
                {

                    direccionHorizontal = 1;
                    sr.flipX = false;
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

        target = GameObject.Find("Rectangle");
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
