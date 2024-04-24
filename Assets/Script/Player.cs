using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    public static bool comItem;

    [Header("MoviConf")]
    public float forwardSpeed = 5f;
    public float atualforwardSpeed;
    public float strafeSpeed = 3f;
    public float atualstrafeSpeed;
    public static bool parado;
    bool agachado;
    public bool isRunnig;

    [Header("LanternConf")]
    public GameObject lanternaObjeto;
    public Light lanterna;
    public float bateriaMax;
    public static float bateriaAtual;
    public Slider imagemBateria;

    public Animator handsAnim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        atualforwardSpeed = forwardSpeed;
        atualstrafeSpeed = strafeSpeed;
        bateriaAtual = bateriaMax;
    }


    void Update()
    {
        if (parado == false)
        {
            Move();
            //Agachar();
            Lanterna();
        }
    }
    void Move()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * atualforwardSpeed * transform.forward;
        strafe = strafeInput * atualstrafeSpeed * transform.right;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        finalVelocity.Normalize();

        controller.Move(finalVelocity * atualforwardSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift) && agachado == false)
        {
            atualforwardSpeed = 2 * forwardSpeed;
            atualstrafeSpeed = 2 * strafeSpeed;
            isRunnig = true;

            handsAnim.SetFloat("isRunnig", 1);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && agachado == false)
        {
            atualforwardSpeed = forwardSpeed;
            atualstrafeSpeed = strafeSpeed;
            isRunnig = false;
            handsAnim.SetFloat("isRunnig", 0);
        }

    }
    void Lanterna()
    {
        // Verifica se a lanterna está ligada
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLanterna();

        }

        // Verifica se a lanterna está ligada e a bateria não está vazia
        if (lanterna.enabled && bateriaAtual > 0)
        {
            // Reduz a bateria com o tempo (ajuste o valor como desejado)
            if (parado == false)
            {
                bateriaAtual -= Time.deltaTime;
            }

            // Atualiza a intensidade da luz com base na carga da bateria

            if (bateriaAtual >= 7.5f)
            {
                lanterna.intensity = 0.7f;
            }
            else if (bateriaAtual <= 7.5f)
            {
                lanterna.intensity = 0.35f;
            }
        }
        else
        {
            // Desliga a lanterna quando a bateria estiver vazia
            lanterna.enabled = false;
            lanternaObjeto.SetActive(false);
        }

        imagemBateria.value = bateriaAtual;
    }

    void ToggleLanterna()
    {
        // Liga ou desliga a lanterna
        lanterna.enabled = !lanterna.enabled;
        if (lanterna.enabled == true)
        {
            lanternaObjeto.SetActive(true);
        }
        else
        {
            lanternaObjeto.SetActive(false);
        }
    }

    void Agachar()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            agachado = true;
            atualforwardSpeed = 2.5f;
            atualstrafeSpeed = 2.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            agachado = false;
            atualforwardSpeed = forwardSpeed;
            atualstrafeSpeed = strafeSpeed;
        }
    }
}
