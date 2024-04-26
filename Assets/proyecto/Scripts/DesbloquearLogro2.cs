using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearLogro2 : MonoBehaviour
{
    void Start()
    {
        Invoke("DesbloquearLogroMuerte", 1.5f);
    }

    public void DesbloquearLogroMuerte()
    {

        MMAchievementManager.UnlockAchievement("Muerto");
    }
}
