using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCreditos : MonoBehaviour
{
    public void OnClickCreditos()
    {
        MMSceneLoadingManager.LoadScene("Creditos");
    }
}
