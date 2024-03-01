using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarDeNivel : MonoBehaviour
{
    public void OnCambiarDeNivel()
    {
        MMSceneLoadingManager.LoadScene("Nivel2");
        //.
        //Debug.Log("Cambiar de nivel");
    }
}
