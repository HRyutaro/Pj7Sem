using UnityEngine;

public class Porta : MonoBehaviour
{
    public Animator anim;
    public bool interagir;
    public bool trancada = true;
    public string textoChaveIncorreta = "Você precisa da chave correta para abrir esta porta.";

    private void Start()
    {
        anim.SetBool("fechada", false);
        anim.SetBool("aberta", false);
    }

    public void ToggleInteracao()
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
        else
        {
            GameController.instance.ShowInformacao(textoChaveIncorreta);
        }
    }

    public void DestrancarPortaRecepcao()
    {
        if (Inventario.temChaveRecepcao)
        {
            GameController.instance.ShowInformacao("Destrancou");
            trancada = !trancada;
        }
        else
        {
            GameController.instance.ShowInformacao("Precisa de chave recepcao");
        }
    }
}

