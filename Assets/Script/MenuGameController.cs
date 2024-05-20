using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuGameController : MonoBehaviour
{

    public GameObject jogar;
    public GameObject opcoesScreen;
    public GameObject buttonOpcoes;
    public GameObject buttonSair;

    public Slider sensibilityButtonX;
    public Slider sensibilityButtonY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jogarButton()
    {
        SceneManager.LoadScene("Fase");
    }
    public void Showopcoes()
    {
        jogar.SetActive(false);
        opcoesScreen.SetActive(true);
        buttonOpcoes.SetActive(false);
        buttonSair.SetActive(false);
    }
    public void opcoesConfig()
    {
        GameController.instance.cam.sensitivityX = sensibilityButtonX.value;
        GameController.instance.cam.sensitivityY = sensibilityButtonY.value;
    }
    public void voltarOpcoes()
    {
        jogar.SetActive(true);
        opcoesScreen.SetActive(false);
        buttonOpcoes.SetActive(true);
        buttonSair.SetActive(true);
    }

    public void SairGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
