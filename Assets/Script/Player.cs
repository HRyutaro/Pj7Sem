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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        atualforwardSpeed = forwardSpeed;
        atualstrafeSpeed = strafeSpeed;
        currentStamina = maxStamina;
    }


    void Update()
    {
        if (parado == false)
        {
            Move();
            //Agachar();
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

        // Verifica se o jogador está correndo e se tem stamina suficiente
        if (Input.GetKey(KeyCode.LeftShift) && agachado == false && currentStamina > 0)
        {
            atualforwardSpeed = 2 * forwardSpeed;
            atualstrafeSpeed = 2 * strafeSpeed;
            isRunnig = true;

            // Reduz a stamina
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
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

        // Garante que a stamina não exceda o máximo ou se torne negativa
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        controller.Move(finalVelocity * atualforwardSpeed * Time.deltaTime);
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
