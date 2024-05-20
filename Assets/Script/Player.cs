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

    [Header("LanternConf")]
    public GameObject lanternaObjeto;
    public Light lanterna;
    public float bateriaMax;
    public static float bateriaAtual;
    public Slider imagemBateria;


    [Header("Arma")]
    public GameObject arma;
    public Collider armaColider;
    public Animator bastaoAnim;
    public bool CdAtack;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        atualforwardSpeed = forwardSpeed;
        atualstrafeSpeed = strafeSpeed;
        bateriaAtual = bateriaMax;
        currentStamina = maxStamina;
    }


    void Update()
    {
        if (parado == false)
        {
            Move();
            //Agachar();
            Lanterna();
            BrandirArma();
            atacar();
        }
    }
    void atacar()
    {
        if(arma.activeSelf)
        {
            if (Input.GetButtonDown("Fire1")&& CdAtack == false)
            {
                StartCoroutine(atackAnim());
            }

        }
    }

    IEnumerator atackAnim()
    {
        armaColider.enabled = true;
        bastaoAnim.SetFloat("atacking", 1);
        yield return new WaitForSeconds(1f);
        armaColider.enabled = false;
        bastaoAnim.SetFloat("atacking", 0);
        CdAtack = true;
        Debug.Log("cd");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("pode");
        CdAtack = false;
    }
    void BrandirArma()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            toggleArma();
        }
    }
    void toggleArma()
    {
        if(arma.activeSelf)
        {
            arma.SetActive(false);
        }
        else
        {
            arma.SetActive(true);
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
