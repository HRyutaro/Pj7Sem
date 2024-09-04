using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Porta : MonoBehaviour
{
    public Animator anim;
    bool interagir;
    public bool trancada = true;
    public bool imperrada = false;
    public bool amaldicoada = false;
    public BoxCollider col;

    public GameObject chave;
    public string textoChaveIncorreta = "Preciso da chave correta para abrir esta porta.";
    public AudioSource som;

    private void Start()
    {
        anim.SetBool("fechada", false);
        anim.SetBool("aberta", false);
    }

    public void ToggleInteracao()
    {
        if(amaldicoada == false)
        {
            if (imperrada == false)
            {
                if (trancada == false)
                {
                    interagir = !interagir;
                    if (interagir == true)
                    {
                        anim.SetBool("fechada", false);
                        anim.SetBool("aberta", true);
                        StartCoroutine(StopPlayer());
                        col.isTrigger = true;
                    }
                    else
                    {
                        anim.SetBool("fechada", true);
                        anim.SetBool("aberta", false);
                        StartCoroutine(StopPlayer());
                        col.isTrigger = false;
                    }
                }
                else if (trancada == true)
                {
                    GameController.instance.ShowInformacao(textoChaveIncorreta);
                }
            }
            else
            {
                GameController.instance.ShowInformacao(textoChaveIncorreta);
                som.Play();
            }
        }
        else
        {
            if(puzzlePorta.instance.craniosAtivados == false)
            {
                puzzlePorta.instance.AtivarTodosCranios();
                GameController.instance.ShowInformacao("Parece que um ritual esta trancando essa porta");
                GameController.instance.textDica.text = "Procure Chuvisco\nAche mais paginas sobre o ritual\nDestrua os cranios para acabar com o ritual da porta";
            }
            else
            {
                GameController.instance.ShowInformacao("Preciso acabar com o ritual dessa porta para poder passar");
            }

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

