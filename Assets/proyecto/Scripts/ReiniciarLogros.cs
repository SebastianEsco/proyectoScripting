using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarLogros : MonoBehaviour
{
    public void OnReiniciar()
    {
        foreach(var logro in MMAchievementManager.AchievementsList)
        {
            MMAchievementManager.LockAchievement(logro.AchievementID);
            if(logro.AchievementID == "Recolectador")
            {
                logro.SetProgress(0);
            }
            if (logro.AchievementID == "Recolectador2")
            {
                logro.SetProgress(0);
            }
            if (logro.AchievementID == "Recolectador3")
            {
                logro.SetProgress(0);
            }
        }
    }
}
