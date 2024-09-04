using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginaItem : MonoBehaviour
{
    public int numero;
    public AudioSource som;
    public AudioSource somsfx;
    public void toggle()
    {
        if(numero == 1)
        {
            Inventario.temPag1 = true;
            GameController.instance.textDica.text = "Procure Chuvisco\nAche mais paginas sobre o ritual";
            GameController.instance.ShowInformacao("Uma página rasgada? Parece importante...");
            som.Play();
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if (numero == 2)
        {
            Inventario.temPag2 = true;
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if (numero == 3)
        {
            Inventario.temPag3 = true;
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if(numero == 4)
        {
            Inventario.temPag4 = true;
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if(numero == 5)
        {
            Inventario.temPag5 = true;
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if(numero == 6)
        {
            Inventario.temPag6 = true;
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if (numero == 7)
        {
            Inventario.temDiario1 = true;
            GameController.instance.ShowInformacao("Esse livro tem uma pagina do diario do legista");
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
        else if (numero == 8)
        {
            Inventario.temDiario2 = true;
            GameController.instance.ShowInformacao("Zangado seu maldito");
            somsfx.Play();

            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }

}
