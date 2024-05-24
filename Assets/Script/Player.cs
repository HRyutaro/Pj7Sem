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
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDecreaseRate = 10f;
    public float staminaIncreaseRate = 5f;
    public bool CdCorrida;
    public Animator anim;

    [Header("Hud")]
    public Slider stamina;
    public Image imaStamina;
    public postProcssing postProcessing;
    public GameObject braco;
    public static bool VerBraco;
    public GameObject vidas;
    public static bool cortouBraco;

    public GameObject atackLuz;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        atualforwardSpeed = forwardSpeed;
        atualstrafeSpeed = strafeSpeed;
        currentStamina = maxStamina;
        stamina.maxValue = maxStamina;
        stamina.value = currentStamina;
        cortouBraco = false;
    }


    void Update()
    {
        if (parado == false)
        {
            Move();
            //Agachar();
            stamina.value = currentStamina;
            //toggleAtack();
        }
        else
        {
            anim.SetFloat("Walk", 0);
        }
            toggleVida();
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
        else
        {
            vertical += Physics.gravity * Time.deltaTime; // Aplicando gravidade quando não está no chão
        }

        Vector3 finalVelocity = forward + strafe + vertical;
        finalVelocity.Normalize();

        // Verifica se o jogador está correndo e se tem stamina suficiente
        if (Input.GetKey(KeyCode.LeftShift) && agachado == false && currentStamina > 0)
        {
            if(CdCorrida == false)
            {
                atualforwardSpeed = 2 * forwardSpeed;
                atualstrafeSpeed = 2 * strafeSpeed;
                isRunnig = true;

                // Reduz a stamina
                currentStamina -= staminaDecreaseRate * Time.deltaTime;
            }
        }
        else
        {
            atualforwardSpeed = forwardSpeed;
            atualstrafeSpeed = strafeSpeed;
            isRunnig = false;


            // Se o jogador estava correndo e a stamina acabou, interrompe o movimento
            if (isRunnig)
            {
                finalVelocity = Vector3.zero;

            }
        }

        // Restaura a stamina se o jogador não estiver correndo
        if (!isRunnig && currentStamina < maxStamina)
        {
            currentStamina += staminaIncreaseRate * Time.deltaTime;
        }

        if(currentStamina <= 0)
        {
            imaStamina.color = Color.red;
            CdCorrida = true;
            postProcessing.ToggleChromaticAberration(true);
        }
        if(CdCorrida == true)
        {
            if(currentStamina >= (maxStamina / 2))
            {
                CdCorrida = false;
                imaStamina.color = new Color(0, 125f / 255f, 164f / 255f);
                postProcessing.ToggleChromaticAberration(false);
            }
        }
        // Garante que a stamina não exceda o máximo ou se torne negativa
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        controller.Move(finalVelocity * atualforwardSpeed * Time.deltaTime);

        float walkSpeed = Mathf.Abs(forwardInput) + Mathf.Abs(strafeInput);
        anim.SetFloat("Walk", walkSpeed);
    }


    void toggleVida()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cortouBraco)
        {
            VerBraco = !VerBraco;
        }
        if (VerBraco)
        {
            vidas.SetActive(true);
            braco.SetActive(true);
        }
        if (!VerBraco)
        {
            vidas.SetActive(false);
            braco.SetActive(false);
        }
    }
    void toggleAtack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            atackLuz.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            atackLuz.SetActive(false);
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
