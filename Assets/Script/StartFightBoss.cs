using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFightBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameController.instance.textDica.text = "Destrua Todos os livros antes que o ritual acabe";
        Boss.instance.StartFight();
    }
}
