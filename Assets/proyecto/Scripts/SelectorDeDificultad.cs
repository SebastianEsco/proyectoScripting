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
        if (GameObject.Find("EnemigosNormal"))
        {
            if (dificultad == 1) //DIFICULTAD FACIL
            {
                GameObject.Find("EnemigosNormal").SetActive(false);
                GameObject.Find("PlataformasExtraNormal").SetActive(false);
                GameObject.Find("PlataformasExtraFacil").SetActive(true);
            }
            if (dificultad == 2) //DIFICULTAD NORMAL
            {
                GameObject.Find("PlataformasExtraFacil").SetActive(false);
            }
            if (dificultad == 3) //DIFICULTAD NORMAL
            {
                GameObject.Find("PlataformasExtraFacil").SetActive(false);

            }
        }
    }
}
