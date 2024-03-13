using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarDeNivel : MonoBehaviour
{
    [SerializeField] string nivelACargar;
    public void OnCambiarDeNivel()
    {
        MMSceneLoadingManager.LoadScene(nivelACargar);
        //.
        //Debug.Log("Cambiar de nivel");
    }
}
