using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaveta : MonoBehaviour
{
    bool aberta = false;
    Vector3 posicaoFechada;
    Vector3 posicaoAberta;
    public float distanciaDeAbertura = 1.0f; 
    public float velocidadeDeAbertura = 2.0f;

    void Start()
    {
        posicaoFechada = transform.localPosition;
        posicaoAberta = transform.localPosition + transform.forward * distanciaDeAbertura;
    }

    void Update()
    {
        if (aberta)
        {
            // Move a gaveta em direção à posição final
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicaoAberta, Time.deltaTime * 1);
        }
        else
        {
            // Move a gaveta de volta para a posição inicial
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicaoFechada, Time.deltaTime * 1);
        }
    }

    public void toggleGaveta()
    {
        aberta = !aberta;
    }

}
