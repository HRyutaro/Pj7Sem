using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public static int Baterias;
    public Text textoHud;

    static public bool temChaveRecepcao;

    void Start()
    {
        Baterias = 0;
    }

    void Update()
    {
        UsarBateria();
        AttHudBateria();
    }
    void UsarBateria()
    {
        if (Input.GetKeyDown(KeyCode.R) && Player.parado == false)
        {
            if (Baterias >= 1)
            {
                Player.bateriaAtual += 20;
                Baterias -= 1;
            }
        }
    }
    void AttHudBateria()
    {
        textoHud.text = Baterias.ToString();
    }

}
