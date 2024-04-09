using UnityEngine;

public class Chave : MonoBehaviour
{
    void Update()
    {
    }

    public void toggle()
    {
        Inventario.temChaveRecepcao = true;
        Destroy(gameObject);
    }
}


