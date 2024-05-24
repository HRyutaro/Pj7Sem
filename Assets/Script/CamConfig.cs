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

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (outlineObject != null)
            {
                if (outlineObject.transform != hit.transform)
                {
                    outlineObject.Deselect();
                }
            }

            outlineObject = hit.transform.GetComponent<OutlineObject>();
            if (outlineObject != null)
            {
                outlineObject.Select();
                //Debug.Log(outlineObject.name);
                if (outlineObject.CompareTag("Porta"))
                {
                    porta = hit.transform.GetComponent<Porta>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(porta.trancada == true)
                        {
                            porta.DestrancarPortaRecepcao();
                            outlineObject.Deselect();
                        }
                        else
                        {
                            porta.ToggleInteracao();
                            outlineObject.Deselect();
                        }
                    }
                }
                if (outlineObject.CompareTag("Chave"))
                {
                    chave = hit.transform.GetComponent<Chave>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        chave.toggle();
                        outlineObject.Deselect();
                    }
                }
                if (outlineObject.CompareTag("PagItem"))
                {
                    pagitem = hit.transform.GetComponent<PaginaItem>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pagitem.toggle();
                        outlineObject.Deselect();
                    }
                }
                if (outlineObject.CompareTag("Gaveta"))
                {
                    gaveta = hit.transform.GetComponent<Gaveta>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        gaveta.toggleGaveta();
                    }
                }
                if (outlineObject.CompareTag("Gravador"))
                {
                    gravadorItem = hit.transform.GetComponent<GravadorItem>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        gravadorItem.toggleGravador();
                        outlineObject.Deselect();
                    }
                }
                if (outlineObject.CompareTag("Interruptor"))
                {
                    Interruptor = hit.transform.GetComponent<interruptor>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Interruptor.toggleLigarLuz();
                    }
                }
                if (outlineObject.CompareTag("Armario"))
                {
                    armario = hit.transform.GetComponent<Armario>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        armario.toggleEntrarArmario();
                    }
                }
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