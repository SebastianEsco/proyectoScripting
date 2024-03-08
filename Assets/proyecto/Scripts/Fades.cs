using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class Fades : MonoBehaviour
{

    SpriteRenderer sr;
    [MMInspectorButton("FadeIn")] public bool FadeInButton;
    [MMInspectorButton("FadeOut")] public bool FadeOutButton;
    public Color colorInicial;
    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        sr.color = colorInicial;

    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
        Invoke("FadeOut", 3f);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }
    public IEnumerator FadeInCoroutine()
    {
        Color c = sr.color;
        Debug.Log("Ejecutando el Fade In");
        for (float i = 0; i < 1.1f; i += 0.1f)
        {
            
            c.a = i;
            sr.color = c;
            yield return new WaitForSeconds(0.1f);

        }
    }

    public IEnumerator FadeOutCoroutine()
    {
        Color c = sr.color;
        Debug.Log("Ejecutando el Fade out");
        for (float i = 1; i > -0.1f; i -= 0.1f)
        {
            
            c.a = i;
            Debug.Log(c.a);
            sr.color = c;

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeIn();
    }



}
