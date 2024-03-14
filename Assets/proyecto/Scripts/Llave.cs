using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Llave : MonoBehaviour, MMEventListener<PickableItemEvent>
{
    [SerializeField] private GameObject puerta;
    private int contador;
    [SerializeField] private int meta;

    public void Start()
    {
        if (puerta != null)
        {
            puerta.SetActive(false);
        }
        else
        {
            Debug.Log("Puerta no encontrada");
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

        if (e.PickedItem.tag == "Llave")
        {
            contador++;
        }
        if (contador == meta)
        {
            puerta.SetActive(true);
        }


    }

}
