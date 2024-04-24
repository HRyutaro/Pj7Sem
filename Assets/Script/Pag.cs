using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pag : MonoBehaviour
{

    public GameObject paginas;
    
    public GameObject pag1;
    public GameObject pag2;
    public GameObject pag3;
    public GameObject pag4;
    public GameObject pag5;
    public GameObject pag6;

    public GameObject Txt;

    public void VoltarPause()
    {
        paginas.SetActive(false);
        GameController.instance.buttonPaginas.SetActive(true);
        GameController.instance.buttonOpcoes.SetActive(true);
        GameController.instance.buttonSair.SetActive(true);
    }

    public void MostrarPaginas()
    {
        paginas.SetActive(true);
        GameController.instance.buttonPaginas.SetActive(false);
        GameController.instance.buttonOpcoes.SetActive(false);
        GameController.instance.buttonSair.SetActive(false);
    }

    public void MostrarPag1()
    {
        if (Inventario.temPag1 == true)
        {
            pag1.SetActive(true);
            pag2.SetActive(false);
            pag3.SetActive(false);
            pag4.SetActive(false);
            pag5.SetActive(false);
            pag6.SetActive(false);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag2.SetActive(false);
        pag3.SetActive(false);
        pag4.SetActive(false);
        pag5.SetActive(false);
        pag6.SetActive(false);
    }
    public void MostrarPag2()
    {
        if (Inventario.temPag2 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(true);
            pag3.SetActive(false);
            pag4.SetActive(false);
            pag5.SetActive(false);
            pag6.SetActive(false);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
        pag3.SetActive(false);
        pag4.SetActive(false);
        pag5.SetActive(false);
        pag6.SetActive(false);
    }
    public void MostrarPag3()
    {
        if (Inventario.temPag3 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(false);
            pag3.SetActive(true);
            pag4.SetActive(false);
            pag5.SetActive(false);
            pag6.SetActive(false);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
        pag2.SetActive(false);
        pag4.SetActive(false);
        pag5.SetActive(false);
        pag6.SetActive(false);
    }
    public void MostrarPag4()
    {
        if (Inventario.temPag4 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(false);
            pag3.SetActive(false);
            pag4.SetActive(true);
            pag5.SetActive(false);
            pag6.SetActive(false);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
        pag2.SetActive(false);
        pag3.SetActive(false);
        pag5.SetActive(false);
        pag6.SetActive(false);
    }
    public void MostrarPag5()
    {
        if (Inventario.temPag5 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(false);
            pag3.SetActive(false);
            pag4.SetActive(false);
            pag5.SetActive(true);
            pag6.SetActive(false);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
        pag2.SetActive(false);
        pag3.SetActive(false);
        pag4.SetActive(false);
        pag6.SetActive(false);
    }
    public void MostrarPag6()
    {
        if (Inventario.temPag6 == true)
        {
            pag1.SetActive(false);
            pag2.SetActive(false);
            pag3.SetActive(false);
            pag4.SetActive(false);
            pag5.SetActive(false);
            pag6.SetActive(true);
            Txt.SetActive(false);
        }
        else
        {
            Txt.SetActive(true);
        }
        pag1.SetActive(false);
        pag2.SetActive(false);
        pag3.SetActive(false);
        pag4.SetActive(false);
        pag5.SetActive(false);
    }
}
