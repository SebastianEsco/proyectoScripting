using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using Unity.VisualScripting;

public class Fades : MonoBehaviour
{

    SpriteRenderer sr;
    [MMInspectorButton("FadeIn")] public bool FadeInButton;
    [MMInspectorButton("FadeOut")] public bool FadeOutButton;
    public Color colorInicial;
    bool reproduciendoFadeIn;
    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        sr.color = colorInicial;

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
        reproduciendoFadeIn = true;
        if(c.a != 1)
        {
            for (float i = c.a; i < 1.1f; i += 0.1f)
            {
                c.a = i;
                sr.color = c;
                yield return new WaitForSeconds(0.1f);

            }
        }
        reproduciendoFadeIn = false;
        
    }

    public IEnumerator FadeOutCoroutine()
    {
        Color c = sr.color;

        for (float i = c.a; i > -0.1f; i -= 0.1f)
        {

            c.a = i;
            sr.color = c;
            if (reproduciendoFadeIn)
            {
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        FadeIn();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("FadeOut", 2f);
    }



}
