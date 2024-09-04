using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelDesenha : MonoBehaviour
{
    public Text panelCode;
    public string senha;
    public GameObject cofre;
    private int maxNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicou(string x)
    {
        if(maxNumber < 4)
        {
            panelCode.text += x;
            maxNumber++;
        }
    }

    public void Enter()
    {
        if(panelCode.text == senha)
        {
            Debug.Log("Certou");
            cofre.SetActive(false);
            Destroy(cofre, 1);
            GameController.instance.OpenPanelCode();
        }
        else
        {
            Debug.Log("errou");
            panelCode.text = "";
            maxNumber = 0;
        }
    }
}
