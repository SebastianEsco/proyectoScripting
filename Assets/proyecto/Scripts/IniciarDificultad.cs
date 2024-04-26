using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarDificultad : MonoBehaviour
{
    SelectorDeDificultad selector;
    [SerializeField] int dificultadAPoner;
    void Start()
    {
        if (GameObject.Find("SelectorDeDificultad"))
        {
            selector = GameObject.Find("SelectorDeDificultad").GetComponent<SelectorDeDificultad>();
            selector.SettearDificultad();

        }

        
        
    }

    public void OnEscogerDificultad()
    {
        selector.EscogerDificultad(dificultadAPoner);
    }

}
