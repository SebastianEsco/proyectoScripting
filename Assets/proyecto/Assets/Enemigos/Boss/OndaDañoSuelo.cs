using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaDañoSuelo : MonoBehaviour
{
    Vector2 posicionInicial, escalaInicial;
    public int direccion;
    public bool activado;
    public bool reiniciar;
    public float velocidad;
    public GameObject visual;
    void Start()
    {
        posicionInicial = transform.position;
        escalaInicial = transform.localScale;
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       Activar();
       Reiniciar();
    }
    public void Reiniciar()
    {
        if(reiniciar)
        {
            visual.SetActive(false);
            transform.position = posicionInicial;
            transform.localScale = escalaInicial;
        }
    }

    public void Activar()
    {
        if (activado)
        {
            visual.SetActive(true);
            if(transform.localScale.x < 3)
            {
                transform.localScale += Vector3.one * 4 * Time.deltaTime;
                transform.Translate(Vector2.up * velocidad/5 *  Time.deltaTime);

            }
            transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);
        }
    }
}
