using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour   
{
    [SerializeField] TextMeshProUGUI temporizador;


    [SerializeField] float tiempo;

    
    void Update()
    {
        tiempo -= Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempo/60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        temporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        if (minutos == 0  && segundos == 0) {
            MMSceneLoadingManager.LoadScene(GameManager.Instance.GameOverScene);
        }
    }
}
