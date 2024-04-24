using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour, MMEventListener<HealthChangeEvent>
{
    DobleKill doblekill;
    void OnEnable()
    {
        this.MMEventStartListening<HealthChangeEvent>();
    }
    

    void OnDisable()
    {
        this.MMEventStopListening<HealthChangeEvent>();
    }

    public virtual void OnMMEvent(HealthChangeEvent e)
    {
        Debug.Log(e);
        Debug.Log(e.NewHealth);
        Debug.Log("Entró");
        doblekill.Kill();
    }


    private void Start()
    {
        doblekill = GameObject.Find("Enemigos").GetComponent<DobleKill>();
    }

   
}
