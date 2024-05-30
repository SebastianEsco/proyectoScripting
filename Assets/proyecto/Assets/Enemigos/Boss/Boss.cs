using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject orbeCuracion;
    int direccionHorizontal;
    float alturaInicial, posicionInicial;
    public float velocidadDeIdle, distanciaDeIdle;
    public GameObject target;
    SpriteRenderer sr;
    Vector2 vectorPosicionInicial;
    public bool activarIdle;
    Health vida;

    Animator animator;
    bool animacionMuerte;
    public bool curacionEnCoolDown;
    public float tiempoCooldownCuracion;


    [MMInspectorButton("ActivarEstadoBoton")] public bool ProbarEstado;
    public string estadoParaBoton;

    //ESTADOS
    List<Estado> listaEstados = new List<Estado>();
    Estado idle = new Estado("Idle", false);
    Estado tieso = new Estado("Tieso", false);
    Estado curacion = new Estado("Curando", false);

   
    private void Awake()
    {
        alturaInicial = transform.localPosition.y;
        posicionInicial = transform.localPosition.x;
    }
    private void Start()
    {
        direccionHorizontal = 1;
        sr = GetComponent<SpriteRenderer>();
        listaEstados.Add(idle);
        listaEstados.Add(tieso);
        listaEstados.Add(curacion);
        animator = GetComponent<Animator>();
        vida = GetComponent<Health>();
    }

    private void Update()
    {

        target = GameObject.Find("Rectangle");

        Idle();
        Tieso();
        Curacion();
        
    }

    public void ActivarEstado(string estado)
    {
        foreach (var e in listaEstados)
        {
            if(e.nombre == estado)
            {
                e.estado = true;
            }
            else
            {
                e.estado = false;
            }
        }
    }

    public void Tieso() //MUERTE
    {
        if (tieso.estado)
        {
            if(transform.localPosition.y > 3.5f)
            {
                transform.Translate(Vector2.down * 5 * Time.deltaTime);
            }
            print("TIESOOO");
            if (!animacionMuerte)
            {
                animator.Play("MuerteBoss");
                animacionMuerte = true;
            }

        }
    }
    public void Idle()
    {
        vectorPosicionInicial = new Vector2(posicionInicial, alturaInicial);
        if (idle.estado)
        {

            print("En IDDLE");
            if (distanciaDeIdle != 0)
            {
                //Patrullar
                transform.Translate(Vector2.right * direccionHorizontal * velocidadDeIdle * Time.deltaTime);


                if (vectorPosicionInicial.x + (-vectorPosicionInicial.x + transform.localPosition.x) > vectorPosicionInicial.x + distanciaDeIdle)
                {
                    direccionHorizontal = -1;
                    sr.flipX = true;
                }
                else if (vectorPosicionInicial.x + (-vectorPosicionInicial.x + transform.localPosition.x) < vectorPosicionInicial.x - distanciaDeIdle)
                {
                    direccionHorizontal = 1;
                    sr.flipX = false;
                }
            }

        } 

    }

    public void Curacion()
    {
        if (curacion.estado && !curacionEnCoolDown)
        {
            curacionEnCoolDown = true;
            Invoke("CooldownCuracion", tiempoCooldownCuracion);
            for (int i = 0; i < (10 - (vida.CurrentHealth/10)); i++)
            {
                int randomHorizontal, randomVertical;
                randomHorizontal = Random.Range(-4, 4); randomVertical = Random.Range(-4, 4);
                int extraHorizontal = 7; int extraVertical = 7;
                if(randomHorizontal < 0) {extraHorizontal *= -1;}
                if (randomVertical < 0) {extraVertical *= -1;}

                print("Istanciando");
                Instantiate(orbeCuracion, 
                    new Vector2((transform.position.x + randomHorizontal + extraHorizontal),
                                (transform.position.y + randomVertical + extraVertical)),
                    Quaternion.identity);
            }
        }
    }
    public void CooldownCuracion()
    {
        curacionEnCoolDown = false;
    }

    public class Estado
    {
        public string nombre;
        public bool estado;
        public Estado(string nombre, bool estado)
        {
            this.nombre = nombre;
            this.estado = estado;
        }
    }

    public void ActivarEstadoBoton()
    {
        ActivarEstado(estadoParaBoton);
    }
}
