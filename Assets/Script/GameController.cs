using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isPause = false;
    public GameObject pauseScreen;
    public Text textInfo;
    public Text textDica;
    public Text textInteracao;


    public CamConfig cam;

    public GameObject opcoesScreen;
    public GameObject buttonPaginas;
    public GameObject buttonGravadores;
    public GameObject buttonOpcoes;
    public GameObject buttonSair;
    public GameObject buttonControles;
    public GameObject buttonConfigs;

    public Slider sensibilityButtonX;
    public Slider sensibilityButtonY;
    public Slider brilobutton;

    public Image ima;
    public float brilhoNum;

    public bool showLeitura;
    public float tempoShowInfo = 3;
    void Start()
    {
        instance = this;
        pauseScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        textInfo.enabled = false;

        sensibilityButtonX.value = cam.sensitivityX;
        sensibilityButtonY.value = cam.sensitivityY;
        textDica.text = "Clique tab para abrir o caderno do Nick";
        ima.color = new Color(0, 0, 0, brilhoNum);
    }


    void Update()
    {
        brilhoNum = brilobutton.value;
        ima.color = new Color(0, 0, 0, brilhoNum);
        if (Input.GetKeyDown(KeyCode.Escape) && Inventario.invetarioOpen == false)
        {
            Pause();
        }
    }
    void Pause()
    {
        isPause = !isPause;

        if(isPause == true )
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void ShowInformacao(string x)
    {
        textInfo.text = x;
        StartCoroutine(habilitarLegenda());
    }
    public void ShowInformacaoArmario(string x)
    {
        textInfo.text = x;
    }
    public void ShowInteracao(string x)
    {
        textInteracao.text = x;
    }
    public void hideInteracao()
    {
        textInteracao.text = "";
    }
    public void ShowHideLeitura(GameObject Imagem)
    {
        showLeitura = !showLeitura;
        Imagem.SetActive(showLeitura);
    }

    IEnumerator habilitarLegenda()
    {
        textInfo.enabled = true;
        yield return new WaitForSeconds(tempoShowInfo);
        textInfo.enabled = false;
        textInfo.text = "";
    }
    public void Showopcoes()
    {
        opcoesScreen.SetActive(true);
        buttonOpcoes.SetActive(false);
        buttonSair.SetActive(false);
    }

    public void ShowControles()
    {
        buttonControles.SetActive(true);
        buttonConfigs.SetActive(false);
    }
    public void ShowConfigs()
    {
        buttonControles.SetActive(false);
        buttonConfigs.SetActive(true);
    }
    public void opcoesConfig()
    {
        cam.sensitivityX = sensibilityButtonX.value;
        cam.sensitivityY = sensibilityButtonY.value;
    }
    public void voltarOpcoes()
    {
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
