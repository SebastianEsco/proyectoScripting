using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buitre : MonoBehaviour
{
    int direccionVertical, direccionHorizontal;
    bool persiguiendoJugador;
    float alturaInicial, posicionInicial;
    public float velocidadDePatrullaje, distanciaDePatrullaje;
    float velocidadDeRecuperacion = 2;

    private void Start()
    {
        alturaInicial = transform.position.y;
        posicionInicial = transform.position.x;
    }

    private void Update()
    {
        if(!persiguiendoJugador)
        {
            //Patrullar

            transform.Translate(0, velocidadDePatrullaje * direccionHorizontal * Time.deltaTime , 0);
            if(Mathf.Abs(transform.position.x - posicionInicial) > distanciaDePatrullaje)
            {
                direccionHorizontal *= -1;
            }

            if(alturaInicial != transform.position.y)
            {
                if(alturaInicial < transform.position.y)
                {
                    //ir hacia abajo
                    direccionVertical = -1;
                }
                else
                {
                        direccionVertical = 1;
                }

                transform.Translate(velocidadDeRecuperacion * direccionVertical * Time.deltaTime, 0, 0);
            }
        }

        if(persiguiendoJugador )
        {

        }
    }
}
