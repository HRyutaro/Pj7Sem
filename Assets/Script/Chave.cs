using UnityEngine;

public class Chave : MonoBehaviour
{
    public bool chaveArquivos;
    public bool ChaveVestiario;
    public bool ChaveSlLegista;
    public bool ChaveLaboratorio;
    public bool ChaveArmazem;
    
    void Update()
    {
    }

    public void toggle()
    {
        if(chaveArquivos)
        {
            Inventario.temChaveArquivos = true;
            GameController.instance.ShowInformacao("Deve ser a chave dos arquivos");
        }
        if (ChaveVestiario)
        {
            Inventario.temChaveVestiario = true;
            GameController.instance.ShowInformacao("Deve ser a chave dos Vestiario");
        }
        if (ChaveSlLegista)
        {
            Inventario.temChaveSlLegista = true;
            GameController.instance.ShowInformacao("Deve ser a chave da Sala do legista");
        }
        if (ChaveLaboratorio)
        {
            Inventario.temChaveLaboratorio = true;
            GameController.instance.ShowInformacao("Deve ser a chave do laboratorio");
        }
        if (ChaveArmazem)
        {
            Inventario.temChaveArmazem = true;
            GameController.instance.ShowInformacao("Deve ser a chave do Armazem");
        }
        gameObject.SetActive(false);
    }
}


