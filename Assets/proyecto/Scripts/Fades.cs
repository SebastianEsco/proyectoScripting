using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class Fades : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    
    SpriteRenderer sr;
    [MMInspectorButton("FadeIn")] public bool FadeInButton;
    [MMInspectorButton("FadeOut")] public bool FadeOutButton;
    public Color colorInicialCuadro, colorInicialTexto;
    bool reproduciendoFadeIn;
    
    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        sr.color = colorInicialCuadro;
        text.color = colorInicialTexto;
        

    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }
    public IEnumerator FadeInCoroutine()
    {
        Color c = sr.color;
        Color ctext = text.color;
        reproduciendoFadeIn = true;
        if(c.a != 1)
        {
            for (float i = c.a; i < 1.1f; i += 0.1f)
            {
                c.a = i;
                ctext.a = i;
                text.color = ctext;
                sr.color = c;
                yield return new WaitForSeconds(0.1f);

            }
        }
        reproduciendoFadeIn = false;
        
    }

    public IEnumerator FadeOutCoroutine()
    {
        Color c = sr.color;
        Color ctext = text.color;

        for (float i = c.a; i > -0.1f; i -= 0.1f)
        {

            c.a = i;
            sr.color = c;
            ctext.a = i;
            text.color = ctext;
            if (reproduciendoFadeIn)
            {
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadeIn();
        }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("FadeOut", 2f);
        }
        
    }



}
