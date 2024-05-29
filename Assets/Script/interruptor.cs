using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interruptor : MonoBehaviour
{
    private bool ligar;
    private bool repetir = true;
    public GameObject lampadas;
    public GameObject Luzes;
    public float tempoligado;
    public AudioSource som;

    private void Update()
    {
        if (ligar && repetir)
        {
            ligarLuz();
            Invoke("desligarLuz", tempoligado);
            repetir = false;
             // Define ligar como falso para evitar chamadas repetidas
        }
    }

    public void ToggleLigarLuz()
    {
        if(!ligar)
        {
            ligar = true;
            som.Play();
        }
    }

    void ligarLuz()
    {
        Vector3 novaPosicao = lampadas.transform.position;
        novaPosicao.y = 10f; // Subtrai 10 unidades da posição atual no eixo Y
        lampadas.transform.position = novaPosicao;
        Luzes.SetActive(true);
    }

    void desligarLuz()
    {
        som.Play();
        Vector3 novaPosicao = lampadas.transform.position;
        novaPosicao.y = -10f; // Subtrai 10 unidades da posição atual no eixo Y
        lampadas.transform.position = novaPosicao;
        Luzes.SetActive(false);
        ligar = false;
        repetir = true;
    }

}

