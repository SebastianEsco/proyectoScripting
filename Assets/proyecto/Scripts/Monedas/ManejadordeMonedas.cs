using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadordeMonedas : MonoBehaviour, MMEventListener<PickableItemEvent>
{

    private int monedasRecolectadas;
    [SerializeField] private GameObject puerta;

    public void Start()
    {
        if (puerta != null)
        {
            puerta.SetActive(false);
        }
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

        if(monedasRecolectadas == 4 && puerta != null)
        {
            //Debug.Log("Puerta Abiertaa");
            

        }
        if(e.PickedItem.name == "llave")
        {
            puerta.SetActive(true);
        }

    }
}
