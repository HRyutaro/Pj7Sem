using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginaItem : MonoBehaviour
{
    public int numero;
    public AudioSource som;
    public void toggle()
    {
        if(numero == 1)
        {
            Inventario.temPag1 = true;
            GameController.instance.textDica.text = "Procure Chuvisco\nAche mais pags sobre o ritual";
            som.Play();

            Destroy(gameObject);
        }
        else if (numero == 2)
        {
            Inventario.temPag2 = true;
            Destroy(gameObject);
        }
        else if (numero == 3)
        {
            Inventario.temPag3 = true;
            Destroy(gameObject);
        }
        else if(numero == 4)
        {
            Inventario.temPag4 = true;
            Destroy(gameObject);
        }
        else if(numero == 5)
        {
            Inventario.temPag5 = true;
            Destroy(gameObject);
        }
        else if(numero == 6)
        {
            Inventario.temPag6 = true;
            Destroy(gameObject);
        }
    }
}
