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

    public float tempoShowInfo = 3;
    void Start()
    {
        instance = this;
        pauseScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        textInfo.enabled = false;
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
}
