using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Start()
    {
        // Encontra o objeto Player na cena pelo nome ou tag
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Faz o objeto olhar para o Player apenas uma vez no Start
            transform.LookAt(player.transform);
        }
    }
}
