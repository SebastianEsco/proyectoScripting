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
        direccionHorizontal = 1;
    }

    private void Update()
    {
        if(!persiguiendoJugador)
        {
            //Patrullar
            Debug.Log("gola");
            transform.Translate(0, velocidadDePatrullaje * direccionHorizontal * Time.deltaTime , 0);
            print(Mathf.Abs(-transform.position.x + posicionInicial) + "VS " + posicionInicial + distanciaDePatrullaje);

            if(-transform.position.x + posicionInicial > posicionInicial + distanciaDePatrullaje)
            {
                direccionHorizontal = -1;
            }
            else
            {
                direccionHorizontal = 1;
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

                transform.Translate(Vector2.right * velocidadDeRecuperacion * direccionVertical * Time.deltaTime);
            }
        }

        if(persiguiendoJugador )
        {

        }
    }
}
