using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharDialogo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogo;
    public GameObject dialogo1;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameController.instance.textDialogo.text = "";
            dialogo.SetActive(false);
            dialogo1.SetActive(false);
            Player.parado = false;
        }
    }
}
