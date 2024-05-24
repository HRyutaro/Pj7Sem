using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarAudio : MonoBehaviour
{
    public AudioSource som;
    public GameObject vidas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.parado = true;
            som.Play();
            vidas.SetActive(true);
            StartCoroutine(PodeMexer());
            Destroy(gameObject, 20);
        }
    }

    IEnumerator PodeMexer()
    {
        yield return new WaitForSeconds(7);
        Player.parado = false;
    }
}

