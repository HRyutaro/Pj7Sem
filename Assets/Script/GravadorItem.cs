using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravadorItem : MonoBehaviour
{
    public int numero;
    public AudioSource audiosource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGravador()
    {
        if (numero == 1)
        {
            Inventario.temGravador1= true;
            audiosource.Play();
            GameController.instance.textDica.text = "Explore e descubra mais sobre o paradeiro de Chuvisco";
        }
        else if (numero == 2)
        {
            Inventario.temGravador2 = true;
        }
        else if (numero == 3)
        {
            Inventario.temGravador3 = true;
        }
        else if (numero == 4)
        {
            Inventario.temGravador4 = true;
        }
        else if (numero == 5)
        {
            Inventario.temGravador5 = true;
        }
        else if (numero == 6)
        {
            Inventario.temGravador6 = true;
        }
        Destroy(gameObject);
    }
}
