using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarAudio : MonoBehaviour
{
    public AudioSource som;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.parado = true;
            som.Play();
            Player.cortouBraco = true;
            Player.VerBraco = true;
            GameController.instance.ShowInformacao("Aperte 'Q' para Levantar/Abaixar vida");
            StartCoroutine(PodeMexer());
            Destroy(gameObject, 7);
        }
    }

    IEnumerator PodeMexer()
    {
        yield return new WaitForSeconds(6);
        Player.parado = false;
    }
}

