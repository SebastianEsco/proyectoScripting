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

    bool estadoValido;

    Animator animator;
    bool animacionMuerte;
    public bool curacionEnCoolDown;
    public float tiempoCooldownCuracion;

    int ultimoEstado;
    Health vidaScript;

    GameObject circuloExplosion;
    float exponencial = 1;

    public float delayGolpeSuelo, timerDelayGolpeSuelo;
    public GameObject onda1, onda2;

    float timerCambiosDeEstado;


    [MMInspectorButton("ActivarEstadoBoton")] public bool ProbarEstado;
    public string estadoParaBoton;

    //ESTADOS
    List<Estado> listaEstados = new List<Estado>();
    Estado idle = new Estado("Idle", false);
    Estado tieso = new Estado("Tieso", false);
    Estado curacion = new Estado("Curando", false);
    Estado explotar = new Estado("Explotar", false);
    Estado golpeAlSuelo = new Estado("GolpearSuelo", false);

   
    private void Awake()
    {
        alturaInicial = transform.localPosition.y;
        posicionInicial = transform.localPosition.x;
    }
    private void Start()
    {
        vectorPosicionInicial = new Vector2(posicionInicial, alturaInicial);
        circuloExplosion = GameObject.Find("Explotar");
        direccionHorizontal = 1;
        sr = GetComponent<SpriteRenderer>();
        listaEstados.Add(idle);
        listaEstados.Add(tieso);
        listaEstados.Add(curacion);
        listaEstados.Add(explotar);
        listaEstados.Add(golpeAlSuelo);
        animator = GetComponent<Animator>();
        vida = GetComponent<Health>();

    }

    private void Update()
    {

        target = GameObject.Find("Rectangle");

        if (timerCambiosDeEstado <= 0)
        {
            float randomTiempo = Random.Range(7, 10);
            timerCambiosDeEstado = randomTiempo;
            print("Supuesto  Cambio de estado");
            CambioAcutomaticoDeEstado();


        }
        else
        {
            timerCambiosDeEstado -= Time.deltaTime;
        }

       
        


        Idle();
        Curacion();
        Explotar();
        GolpeAlSuelo();
        if (gameObject.GetComponent<Health>().CurrentHealth <= 0)
        {
            ActivarEstado("Tieso");
            Tieso();
        }
        
    }

    public void CambioAcutomaticoDeEstado()
    {
        estadoValido = false;
        int randomEstado = 0;
        while (!estadoValido)
        {
            randomEstado = Random.Range(0, listaEstados.Count);
            if(randomEstado == 1 || randomEstado == ultimoEstado)
            {
                estadoValido = false;
            }
            else
            {
                estadoValido = true;
            }
        }
        ultimoEstado = randomEstado;
        ActivarEstado(listaEstados[randomEstado].nombre);
        
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
            if(transform.localPosition.y > -2.5f)
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
            animator.SetBool("Curandose", false);

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

            GetComponent<Health>().Invulnerable = true;
            animator.Play("CuracionBoss");
            animator.SetBool("Curandose", true);
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
        else
        {
            GetComponent<Health>().Invulnerable = false;
        }
    }
    public void CooldownCuracion()
    {
        curacionEnCoolDown = false;
    }

    public void Explotar()
    {
        if (explotar.estado)
        {
            animator.SetBool("Explotando", true);
            animator.SetBool("Curandose", false);
            if(circuloExplosion.transform.localScale.x < 1.75)
            {
                exponencial *= 1.009f;
                circuloExplosion.transform.localScale += Vector3.one * exponencial * Time.deltaTime * Time.deltaTime;
            }
        }
        else
        {
            animator.SetBool("Explotando", false);
            if (circuloExplosion.transform.localScale.x > 0.1)
            {
                exponencial = 1;
                circuloExplosion.transform.localScale -= Vector3.one * 60 * Time.deltaTime * Time.deltaTime;
            }
        }
    }

    public void GolpeAlSuelo()
    {
        if (golpeAlSuelo.estado)
        {

            onda1.GetComponent<OndaDañoSuelo>().reiniciar = false;
            onda2.GetComponent<OndaDañoSuelo>().reiniciar = false;
            if (timerDelayGolpeSuelo > 0)
            {
                timerDelayGolpeSuelo -= Time.deltaTime;
                if (transform.localPosition.y > -2.5f)
                {
                    transform.Translate(Vector2.down * 5 * Time.deltaTime); //Bajar al suelo
                }
                
            }
            else
            {
                
                onda1.GetComponent<OndaDañoSuelo>().activado = true;
                onda2.GetComponent<OndaDañoSuelo>().activado = true;


            }
            if(timerDelayGolpeSuelo < 1.25f)
            {
                //PLAY ANIMACION
                animator.Play("GolpearSueloBoss");
                animator.SetBool("GolpeandoSuelo", true);
            }

           

            
        }
        else
        {
            timerDelayGolpeSuelo = delayGolpeSuelo;
            animator.SetBool("GolpeandoSuelo", false);
            if (transform.position.y < alturaInicial)
            {
                transform.Translate(Vector2.up * 3 * Time.deltaTime);
            }
            onda1.GetComponent<OndaDañoSuelo>().activado = false;
            onda2.GetComponent<OndaDañoSuelo>().activado = false;
            onda1.GetComponent<OndaDañoSuelo>().reiniciar = true;
            onda2.GetComponent<OndaDañoSuelo>().reiniciar = true;
        }
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
