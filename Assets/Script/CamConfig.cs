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

    void Start()
    {

    }
    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        if (GameController.instance.isPause == false)
        {
            if (Player.parado == false)
            {
                ControleCam();
            }
            look();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
                if (outlineObject.CompareTag("Bateria"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Inventario.Baterias <= 4)
                        {
                            Inventario.Baterias++;
                            Destroy(outlineObject.gameObject);
                        }
                        else
                        {
                            GameController.instance.ShowInformacao("Ja tenho muitos guardados");
                        }
                    }
                }
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
            }
        }
    }
}