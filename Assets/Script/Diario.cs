using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diario : MonoBehaviour
{

    public GameObject paginas;

    public GameObject pag1;
    public GameObject pag2;

    public GameObject Txt;

    public void VoltarPause()
    {
        paginas.SetActive(false);
        GameController.instance.buttonPaginas.SetActive(true);
        GameController.instance.buttonGravadores.SetActive(true);
        GameController.instance.buttonDiario.SetActive(true);
    }

    public void MostrarPaginas()
    {
        paginas.SetActive(true);
        GameController.instance.buttonPaginas.SetActive(false);
        GameController.instance.buttonGravadores.SetActive(false);
        GameController.instance.buttonDiario.SetActive(false);
    }

    public void MostrarPag1()
    {
        if (Inventario.temDiario1 == true)
        {
            pag1.SetActive(true);
            pag2.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag2.SetActive(false);
    }
    public void MostrarPag2()
    {
        if (Inventario.temDiario2 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(true);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
    }

}
