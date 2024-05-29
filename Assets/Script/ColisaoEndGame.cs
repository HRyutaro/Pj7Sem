using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoEndGame : MonoBehaviour
{
    public GameObject telaEnd;
    void Start()
    {
        telaEnd.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Player.parado = false;
            Destroy(telaEnd);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        telaEnd.SetActive(true);
        Player.parado = true;
    }
}
