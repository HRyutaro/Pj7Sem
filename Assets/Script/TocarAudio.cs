using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarAudio : MonoBehaviour
{
    public AudioSource som;
    public AudioSource som1;
    public BoxCollider proprio;
    private void Start()
    {
        Invoke("startAudio", 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            proprio.enabled = false;
            Player.parado = true;
            som1.Play();
            Player.cortouBraco = true;
            Player.VerBraco = true;
            GameController.instance.ShowInformacao("Aperte 'Q' para Levantar/Abaixar vida");
            StartCoroutine(PodeMexer());
            Destroy(gameObject, 7);
        }
    }

    void startAudio()
    {
        som.Play();
    }
    IEnumerator PodeMexer()
    {
        yield return new WaitForSeconds(6);
        Player.parado = false;
    }
}

