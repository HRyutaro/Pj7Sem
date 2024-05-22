using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Porta : MonoBehaviour
{
    public Animator anim;
    bool interagir;
    public bool trancada = true;
    public bool imperrada = false;
    public GameObject chave;
    public string textoChaveIncorreta = "Preciso da chave correta para abrir esta porta.";

    private void Start()
    {
        anim.SetBool("fechada", false);
        anim.SetBool("aberta", false);
    }

    public void ToggleInteracao()
    {
        if(imperrada== false)
        {
            if (trancada == false)
            {
                interagir = !interagir;
                if (interagir == true)
                {
                    anim.SetBool("fechada", false);
                    anim.SetBool("aberta", true);
                    StartCoroutine(StopPlayer());
                }
                else
                {
                    anim.SetBool("fechada", true);
                    anim.SetBool("aberta", false);
                    StartCoroutine(StopPlayer());
                }
            }
            else if(trancada == true)
            {
                GameController.instance.ShowInformacao(textoChaveIncorreta);
            }
        }
        else
        {
            GameController.instance.ShowInformacao(textoChaveIncorreta);
        }
    }
    
     IEnumerator StopPlayer()
    {
        Player.parado = true;
        yield return new WaitForSeconds(0.7f);
        Player.parado = false;
    }

    public void DestrancarPortaRecepcao()
    {
        if (chave.activeSelf == false)
        {
            GameController.instance.ShowInformacao("Destrancou");
            trancada = !trancada;
        }
        else
        {
            GameController.instance.ShowInformacao(textoChaveIncorreta);
        }
    }
}

