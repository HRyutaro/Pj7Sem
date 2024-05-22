using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
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
        // Verifica se o objeto que colidiu possui a tag "Enemy"
        if (other.CompareTag("inimigo"))
        {
            // Destrói o objeto inimigo
            Destroy(other.gameObject);
        }
    }
}
