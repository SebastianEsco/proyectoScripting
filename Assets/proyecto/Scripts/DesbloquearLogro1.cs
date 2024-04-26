using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearLogro1 : MonoBehaviour
{
    [SerializeField] string nombreDeLogro;
    [SerializeField] GameObject logroDesbloqueado;
    void Start()
    {
        foreach(var achievement in MMAchievementManager.AchievementsList)
        {
            if(achievement.AchievementID == nombreDeLogro)
            {
                if (achievement.UnlockedStatus)
                {
                    logroDesbloqueado.SetActive(true);
                }
                else
                {
                    logroDesbloqueado.SetActive(false);
                }
            }
        }
    }

    
}
