using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePorta : MonoBehaviour
{
    public static puzzlePorta instance;

    public GameObject[] cranios;
    public GameObject magicCircle;
    public GameObject efeito;
    public GameObject porta;

    private Porta portaScript;

    public bool craniosAtivados = false;
    bool comecouRitual = false;
    public static int destruiuCranios = 0;

    void Start()
    {
        instance = this;
        if (porta != null)
        {
            portaScript = porta.GetComponent<Porta>();
        }
        else
        {
            Debug.LogError("O GameObject 'porta' não foi atribuído.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(comecouRitual)
        {
            if(destruiuCranios == 6)
            {
                portaScript.amaldicoada = false;
                magicCircle.SetActive(false);
                efeito.SetActive(false);
                GameController.instance.textDica.text = "Ache mais paginas sobre o ritual\nAcabe com o ritual";
                comecouRitual = false;
            }
        }
    }

    public void AtivarTodosCranios()
    {
        if (!craniosAtivados)
        {
            for (int i = 0; i < cranios.Length; i++)
            {
                if (cranios[i] != null)
                {
                    cranios[i].SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Um dos objetos no array cranios está nulo.");
                }
            }
            magicCircle.SetActive(true);
            efeito.SetActive(true);
            craniosAtivados = true;
            comecouRitual = true;

        }
    }
}
