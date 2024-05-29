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
        dentroArmario = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dentroArmario)
        {
            mainCamera.SetActive(false);
            lockCamera.SetActive(true);
            bodyPlayer.SetActive(false);
            GameController.instance.textInfo.enabled = true;
            GameController.instance.ShowInformacaoArmario("Aperte 'Space' para Sair");
            GameController.instance.hideInteracao();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dentroArmario = false;
                GameController.instance.ShowInformacaoArmario("");
                GameController.instance.textInfo.enabled = false;
                mainCamera.SetActive(true);
                lockCamera.SetActive(false);
                bodyPlayer.SetActive(true);
            }
        }
    }

    public void toggleEntrarArmario()
    {
        dentroArmario = true;
    }
}
