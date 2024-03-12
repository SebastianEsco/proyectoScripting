using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadordeMonedas : MonoBehaviour, MMEventListener<PickableItemEvent>
{

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
        Debug.Log(e.PickedItem.name);

        monedasRecolectadas++;
        

    }
}
