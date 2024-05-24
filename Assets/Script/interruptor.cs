using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interruptor : MonoBehaviour
{
    private bool ligar;
    public GameObject lampadas;
    public GameObject Luzes;
    public float tempoligado;

    private void Update()
    {
        if (ligar)
        {
            ligarLuz();
            Invoke("desligarLuz", tempoligado);
            ligar = false; // Define ligar como falso para evitar chamadas repetidas
        }
    }

    public void toggleLigarLuz()
    {
        ligar = true;
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
        Vector3 novaPosicao = lampadas.transform.position;
        novaPosicao.y = -10f; // Subtrai 10 unidades da posição atual no eixo Y
        lampadas.transform.position = novaPosicao;
        Luzes.SetActive(false);
    }

}

