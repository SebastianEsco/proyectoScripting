using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleKill : MonoBehaviour
{
    int kill;

    public void Kill()
    {
        kill++;
        Debug.Log("Kill");
        Invoke("SeAcaboElTiempo", 2f);
        RevisarSegundaKill();

        
    }

    public void SeAcaboElTiempo()
    {
        kill = 0;
    }

    public void RevisarSegundaKill()
    {
        if(kill == 2)
        {
            MMAchievementManager.UnlockAchievement("DobleKill");
        }
    }
}
