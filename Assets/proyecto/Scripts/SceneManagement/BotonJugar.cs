using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonJugar : MonoBehaviour
{
    [SerializeField] string nivelACargar;
    [SerializeField] GameObject textoDeElegirDificultad;
    public void OnClickJugar()
    {
        if(GameObject.Find("SelectorDeDificultad").GetComponent<SelectorDeDificultad>().dificultad == 0)
        {
            textoDeElegirDificultad.SetActive(true);
        }
        else
        {
            MMSceneLoadingManager.LoadScene(nivelACargar);
        }
        
    }
}
