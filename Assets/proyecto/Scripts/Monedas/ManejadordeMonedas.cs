using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadordeMonedas : MonoBehaviour, MMEventListener<PickableItemEvent>
{
    [SerializeField] string nivel;
    private int monedasRecolectadas;

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
        Debug.Log(monedasRecolectadas);
        if (monedasRecolectadas >= 50)
        {
            MMAchievementManager.UnlockAchievement("Recolectador");
        }
        if(monedasRecolectadas == 236 && nivel == "1")
        {
            MMAchievementManager.UnlockAchievement("TodasLasMonedasNivel1");
        }
        

    }
}
