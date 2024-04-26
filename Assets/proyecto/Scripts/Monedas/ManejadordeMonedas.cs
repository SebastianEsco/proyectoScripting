using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadordeMonedas : MonoBehaviour, MMEventListener<PickableItemEvent>
{
    [SerializeField] string nivel;
    public int monedasRecolectadas;

    public void Start()
    {

    }
    void OnEnable()
    {
        this.MMEventStartListening<PickableItemEvent>();
    }

    void OnDisable() 
    {
        this.MMEventStopListening<PickableItemEvent>();
    }

    public virtual void OnMMEvent(PickableItemEvent e)
    {
        
        
        monedasRecolectadas++;

        


        MMAchievementManager.AddProgress("Recolectador", 1);
        MMAchievementManager.AddProgress("Recolectador2", 1);
        MMAchievementManager.AddProgress("Recolectador3", 1);
        Debug.Log(monedasRecolectadas);
        if (monedasRecolectadas >= 50)
        {
            MMAchievementManager.UnlockAchievement("Recolectador");
        }
        if(monedasRecolectadas == 236 && nivel == "1")
        {
            MMAchievementManager.UnlockAchievement("TodasLasMonedasNivel1");
        }
        if (monedasRecolectadas == 180 && nivel == "2")
        {
            MMAchievementManager.UnlockAchievement("TodasLasMonedasNivel2");
        }
        if (monedasRecolectadas == 98 && nivel == "3")
        {
            MMAchievementManager.UnlockAchievement("TodasLasMonedasNivel3");
        }
        if (monedasRecolectadas >= 250)
        {
            MMAchievementManager.UnlockAchievement("Recolectador2");
        }
        if (monedasRecolectadas >= 500)
        {
            MMAchievementManager.UnlockAchievement("Recolectador3");
        }


    }
}
