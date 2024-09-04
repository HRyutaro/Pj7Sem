using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cranios : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void toggleInteracao()
    {
        puzzlePorta.destruiuCranios++;
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
