using UnityEngine;

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

                }
                else
                {
                    anim.SetBool("fechada", true);
                    anim.SetBool("aberta", false);
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

