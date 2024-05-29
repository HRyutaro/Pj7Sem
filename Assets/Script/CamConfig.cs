using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamConfig : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public float sensitivityX = 0.5f;
    public float sensitivityY = 0.5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    public float smoothCoefx = 0.005f;
    public float smoothCoefy = 0.005f;
    public float range = 5;
    public float offsetDistance = 1.0f;


    OutlineObject outlineObject;
    Porta porta;
    Chave chave;
    PaginaItem pagitem;
    GravadorItem gravadorItem;
    Gaveta gaveta;
    interruptor Interruptor;
    Armario armario;
    LivroAmaldicoado livroAA;

    void Start()
    {

    }
    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        if (GameController.instance.isPause == false && Inventario.invetarioOpen == false)
        {
            if (Player.parado == false)
            {
                ControleCam();
            }
            look();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
       
    }
    void ControleCam()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx;
        rotationY += smoothRoty;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    void look()
    {
        Vector3 direction = Vector3.forward;
        Vector3 startOffset = transform.forward * offsetDistance;
        Ray theRay = new Ray(transform.position + startOffset, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position + startOffset, transform.TransformDirection(direction * range), Color.red);

        // Verifica se o raio colidiu com algum objeto
        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            // Verifica se o objeto destacado mudou
            if (outlineObject != null)
            {
                if (outlineObject.transform != hit.transform)
                {
                    GameController.instance.hideInteracao();
                    outlineObject.Deselect();
                    outlineObject = null;
                }
            }

            // Obtém o componente OutlineObject do objeto atingido
            outlineObject = hit.transform.GetComponent<OutlineObject>();
            if (outlineObject != null)
            {
                outlineObject.Select();
                HandleOutlineObject(hit); // Processa o objeto destacado
            }
        }
        else if (outlineObject != null) // Caso não haja colisão e um objeto estava destacado
        {
            GameController.instance.hideInteracao();
            outlineObject.Deselect();
            outlineObject = null;
        }
    }
    void HandleOutlineObject(RaycastHit hit)
    {
        // Processa a interação com o objeto destacado de acordo com a tag
        if (outlineObject.CompareTag("Porta"))
        {
            porta = hit.transform.GetComponent<Porta>();
            GameController.instance.ShowInteracao("Aperte 'E' para Abrir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (porta.trancada)
                {
                    porta.DestrancarPortaRecepcao();
                }
                else
                {
                    porta.ToggleInteracao();
                }
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Chave"))
        {
            chave = hit.transform.GetComponent<Chave>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                chave.toggle();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("PagItem"))
        {
            pagitem = hit.transform.GetComponent<PaginaItem>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                pagitem.toggle();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Gaveta"))
        {
            gaveta = hit.transform.GetComponent<Gaveta>();
            GameController.instance.ShowInteracao("Aperte 'E' para Abrir/fechar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                gaveta.toggleGaveta();
            }
        }
        else if (outlineObject.CompareTag("Gravador"))
        {
            gravadorItem = hit.transform.GetComponent<GravadorItem>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                gravadorItem.toggleGravador();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Interruptor"))
        {
            Interruptor = hit.transform.GetComponent<interruptor>();
            GameController.instance.ShowInteracao("Aperte 'E' para Ligar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interruptor.ToggleLigarLuz();
            }
        }
        else if (outlineObject.CompareTag("Armario"))
        {
            armario = hit.transform.GetComponent<Armario>();
            GameController.instance.ShowInteracao("Aperte 'E' para Entrar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                armario.toggleEntrarArmario();
            }
        }
        else if (outlineObject.CompareTag("LivroAA"))
        {
            livroAA = hit.transform.GetComponent<LivroAmaldicoado>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                livroAA.toggleLivro();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 direction = Vector3.forward;
        Vector3 startOffset = transform.forward * offsetDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + startOffset, transform.TransformDirection(direction * range));
    }
}