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

    public static bool temGravador1;
    public static bool temGravador2;
    public static bool temGravador3;
    public static bool temGravador4;
    public static bool temGravador5;
    public static bool temGravador6;

    static public bool invetarioOpen = false;
    public GameObject invetarioHud;
    public GameObject caderno;

    bool AbriuPrimeiravez;
    void Start()
    {
        temPag1 = false;
        temPag2 = false;
        temPag3 = false;
        temPag4 = false;
        temPag5 = false;
        temPag6 = false;

        temGravador1 = false;
        temGravador2 = false;
        temGravador3 = false;
        temGravador4 = false;
        temGravador5 = false;
        temGravador6 = false;

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


            if(AbriuPrimeiravez == false)
            {
                AbriuPrimeiravez = true;
                GameController.instance.textDica.text = "Procure por pistas sobre o Chuvisco Felix";
            }
            if (invetarioOpen)
            {
                invetarioHud.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                caderno.SetActive(true);
            }
            else if( invetarioOpen == false)
            {
                invetarioHud.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                caderno.SetActive(false);
            }
        }
    }
}
