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

    public CamConfig cam;
    public GameObject luz;

    public GameObject opcoesScreen;
    public GameObject buttonOpcoes;
    public GameObject buttonSair;

    public Slider sensibilityButtonX;
    public Slider sensibilityButtonY;
    public Slider brilobutton;

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
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if(isPause == true)
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
