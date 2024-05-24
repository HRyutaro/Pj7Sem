using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject lockCamera;
    public GameObject bodyPlayer;

    bool dentroArmario;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dentroArmario)
        {
            mainCamera.SetActive(false);
            lockCamera.SetActive(true);
            bodyPlayer.SetActive(false);
            GameController.instance.textInfo.enabled = true;
            GameController.instance.ShowInformacaoArmario("Aperte 'E' para Sair");
            if(Input.GetKeyDown(KeyCode.E))
            {
                dentroArmario = false;
                GameController.instance.ShowInformacaoArmario("");
                GameController.instance.textInfo.enabled = false;
            }
        }
        else
        {
            mainCamera.SetActive(true);
            lockCamera.SetActive(false);
            bodyPlayer.SetActive(true);
        }
    }

    public void toggleEntrarArmario()
    {
        dentroArmario = true;
    }
}
