using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearLogro : MonoBehaviour
{
    void Start()
    {
        Invoke("DesbloquearLogroSaltoDeFe", 1.5f);
    }

    public void DesbloquearLogroSaltoDeFe()
    {

        MMAchievementManager.UnlockAchievement("SaltoDeFe");
    }
}
