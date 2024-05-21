using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Text textoHud;

    static public bool temChaveArquivos;
    static public bool temChaveVestiario;
    static public bool temChaveSlLegista;
    static public bool temChaveLaboratorio;
    static public bool temChaveArmazem;


    public static bool temPag1;
    public static bool temPag2;
    public static bool temPag3;
    public static bool temPag4;
    public static bool temPag5;
    public static bool temPag6;

    static public bool invetarioOpen = false;
    public GameObject invetarioHud;

    void Start()
    {
        temPag1 = false;
        temPag2 = false;
        temPag3 = false;
        temPag4 = false;
        temPag5 = false;
        temPag6 = false;
    }

    void Update()
    {
        AbrirInventario();
    }

    void AttHudBateria()
    {
        //textoHud.text = Baterias.ToString();
    }
    void AbrirInventario()
    {
        if(GameController.instance.isPause == false && Input.GetKeyDown(KeyCode.Tab))
        {
            invetarioOpen = !invetarioOpen;
            Player.parado = !Player.parado;

            if (invetarioOpen)
            {
                invetarioHud.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                invetarioHud.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
