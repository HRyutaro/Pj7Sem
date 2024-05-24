using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    Zombie inimigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            // Destrói o objeto inimigo
            inimigo = other.transform.GetComponent<Zombie>();
            inimigo.OnLuz = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            // Destrói o objeto inimigo
            
            inimigo = other.transform.GetComponent<Zombie>();
            inimigo.OnLuz = false;
        }
    }
}
