using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonJugar : MonoBehaviour
{
    public void OnClickJugar()
    {
        MMSceneLoadingManager.LoadScene("Nivel1");
    }
}
