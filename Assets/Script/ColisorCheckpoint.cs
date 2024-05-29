using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorCheckpoint : MonoBehaviour
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
        Player.currentSpawn += 1;
        Destroy(gameObject);
    }
}
