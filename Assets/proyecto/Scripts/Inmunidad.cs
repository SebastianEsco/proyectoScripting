using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmunidad : MonoBehaviour, MMEventListener<PickableItemEvent>
{
    [SerializeField]
    private float tiempo_inmunidad;
    private GameObject _fadeObject;
    private Health salud_personaje;

    [Header("Inmunidad")]
    [MMInspectorButton("ControlInmunidad")]
    public bool ControlInmunidadButton;

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
        if (e.PickedItem.name == "Estrella")
        {
            ControlInmunidad();
        }
    }

    public Health getHealth()
    {
        _fadeObject = LevelManager.Instance.Players[0].gameObject;
        return _fadeObject.GetComponent<Health>();
    }

    public void ControlInmunidad()
    {
        salud_personaje = getHealth();
        salud_personaje.Invulnerable = true;
        StartCoroutine(DesactivarInmunidad());
    }

    public IEnumerator DesactivarInmunidad()
    {
        //Debug.Log("click");
        yield return new WaitForSeconds(tiempo_inmunidad);
        //Debug.Log("tiempo!");
        salud_personaje.Invulnerable = false;
    }
}
