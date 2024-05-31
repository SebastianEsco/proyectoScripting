using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorDeDificultad : MonoBehaviour
{
    public int dificultad;

    public void EscogerDificultad(int dificultadElegida)
    {
        dificultad = dificultadElegida;
    }

    public void SettearDificultad()
    {
        // Encuentra el GameObject del temporizador
        GameObject temporizador = GameObject.Find("UICamera/Canvas/Temporizador");

        // Verifica si el GameObject del temporizador fue encontrado
        if (temporizador != null)
        {
            // Obtiene el componente Temporizador del GameObject
            Temporizador script = temporizador.GetComponent<Temporizador>();

            
                if (dificultad == 1) // DIFICULTAD FÁCIL
                {
                    GameObject.Find("EnemigosNormal").SetActive(false);
                    GameObject.Find("PlataformasExtraNormal").SetActive(false);
                    GameObject.Find("PlataformasExtraFacil").SetActive(true);
                    temporizador.SetActive(false);

                    if (script != null)
                    {
                        script.enabled = false;
                    }
                }
                else if (dificultad == 2) // DIFICULTAD NORMAL
                {
                    GameObject.Find("PlataformasExtraFacil").SetActive(false);
                    temporizador.SetActive(false);

                    if (script != null)
                    {
                        script.enabled = false;
                    }
                }
                else if (dificultad == 3) // DIFICULTAD DIFÍCIL
                {
                    temporizador.SetActive(true);

                    if (script != null)
                    {
                        script.enabled = true;
                    }
                }         
        }
        else
        {
            Debug.LogWarning("No se encontró el GameObject 'Temporizador'.");
        }
    }
}

