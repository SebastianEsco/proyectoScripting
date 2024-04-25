using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorDeDificultad : MonoBehaviour
{
    int dificultad;
    public void EscogerDificultad(int dificultadElegida)
    {
        dificultad = dificultadElegida;
    }

    public void SettearDificultad()
    {
        if (GameObject.Find("Normal"))
        {
            if (dificultad == 1)
            {
                GameObject.Find("EnemigosNormal").SetActive(false);
            }
            if (dificultad == 2)
            {
                GameObject.Find("Facil").SetActive(false);
            }
        }
    }
}
