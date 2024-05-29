using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPensamento04 : MonoBehaviour
{
    public AudioSource som;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        som.Play();
        Destroy(gameObject);
    }
}
