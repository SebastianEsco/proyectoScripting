using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVolverAInicio : MonoBehaviour
{
    public void OnClickBotonVolverAInicio()
    {
        MMSceneLoadingManager.LoadScene("Inicio");
    }
}
