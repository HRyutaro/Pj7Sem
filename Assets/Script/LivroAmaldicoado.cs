using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivroAmaldicoado : MonoBehaviour
{
    public bool destruir;
    private int instanceID;
    void Start()
    {
        instanceID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        if(destruir)
        {
            Boss.instance.OnBookDestroyed();
            Destroy(gameObject);
        }
    }

    public void toggleLivro()
    {
        destruir = true;
    }
}
