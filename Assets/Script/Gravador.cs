using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravador : MonoBehaviour
{
    public GameObject pagGravadores;
    public static int numeroPag;

    public GameObject[] gravadores;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowGravadores()
    {
        pagGravadores.SetActive(true);
        GameController.instance.buttonPaginas.SetActive(false);
        GameController.instance.buttonGravadores.SetActive(false);
        GameController.instance.buttonDiario.SetActive(false);
        numeroPag = 1;
        if (Inventario.temGravador1 == true)
        {
            gravadores[0].SetActive(true);
        }
    }
    public void VoltarGravadores()
    {
        pagGravadores.SetActive(false);
        GameController.instance.buttonPaginas.SetActive(true);
        GameController.instance.buttonGravadores.SetActive(true);
        GameController.instance.buttonDiario.SetActive(true);
    }
    
    /*public void NextGravador()
    {
        if (numeroPag == 1)
        {
            if (Inventario.temGravador1 == true)
            {
                gravadores[0].SetActive(true);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }
        else if (numeroPag == 2)
        {
            if (Inventario.temGravador2 == true)
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(true);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }
        else if (numeroPag == 3)
        {
            if (Inventario.temGravador3 == true)
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(true);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }
        else if (numeroPag == 4)
        {
            if (Inventario.temGravador4 == true)
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(true);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }
        else if (numeroPag == 5)
        {
            if (Inventario.temGravador5 == true)
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(true);
                gravadores[5].SetActive(false);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }
        else if (numeroPag == 6)
        {
            if (Inventario.temGravador6 == true)
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(true);
            }
            else
            {
                gravadores[0].SetActive(false);
                gravadores[1].SetActive(false);
                gravadores[2].SetActive(false);
                gravadores[3].SetActive(false);
                gravadores[4].SetActive(false);
                gravadores[5].SetActive(false);
            }
        }

        if (numeroPag == 1)
        {
            numeroPag = 2;
        }
        else if (numeroPag == 2)
        {
            numeroPag = 3;
        }
        else if (numeroPag == 3)
        {
            numeroPag = 4;
        }
        else if (numeroPag == 4)
        {
            numeroPag = 5;
        }
        else if (numeroPag == 5)
        {
            numeroPag = 6;
        }
        else if (numeroPag == 6)
        {
            numeroPag = 1;
        }
    }
    */

}
