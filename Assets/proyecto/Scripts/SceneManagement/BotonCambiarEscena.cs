using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCambiarEscena : MonoBehaviour
{
    [SerializeField] string nivelACargar;
    
    public void OnClickCambiarEscena()
    {
        MMSceneLoadingManager.LoadScene(nivelACargar);

    }
}
