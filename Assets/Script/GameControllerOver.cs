using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SairGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
