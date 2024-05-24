using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;

    [Header("Controle")]
    public int numberOfRays = 5;
    public float rayAngle = 30f;
    public float yOffset = 1.0f;
    public float offsetDistance = 1.0f;
    public float range = 5;
    private float rangeOriginal;

    private List<RaycastHit> hitList = new List<RaycastHit>();
    private List<RaycastHit> hitList2 = new List<RaycastHit>();

    public Player player;

    public bool OnLuz = false;
    public AudioSource[] grunido;
    public float minCDGrunido = 3f;
    public float maxCDGrunido = 7f;

    [Header("Patrulha")]
    public List<Transform> pontosDeDestino;
    public float tempoEspera = 3f;
    public int numRandom;
    public bool voltar;

    public bool vendoPlayer;

    void Start()
    {
        rangeOriginal = range;
        StartCoroutine(som());
        StartCoroutine(MudarDestinoPeriodicamente());
        agent.destination = pontosDeDestino[numRandom].position;
        agent.stoppingDistance = 0;
    }

    private void FixedUpdate()
    {
        Vector3 startOffset = transform.forward * offsetDistance;
        
        look(startOffset);
        

        if (OnLuz)
        {
            agent.isStopped = true; // Se a luz estiver ativa, pare o agente
        }
        else
        {
            agent.isStopped = false; // Se a luz estiver inativa, permita que o agente se mova
        }

        if(vendoPlayer == true)
        {
            agent.stoppingDistance = 2.5f;
            agent.destination = GameObject.FindWithTag("Player").transform.position;
        }
        else
        {
            agent.destination = pontosDeDestino[numRandom].position;
            agent.stoppingDistance = 0;
        }
    }

    IEnumerator som()
    {
            while (true)
            {
                // Escolhe um grunhido aleatório da lista
                if (grunido.Length > 0)
                {
                    int randomIndex = Random.Range(0, grunido.Length);
                    grunido[randomIndex].Play();
                }

                // Espera por um tempo aleatório entre minTimeBetweenGrowls e maxTimeBetweenGrowls
                float waitTime = Random.Range(minCDGrunido, maxCDGrunido);
                yield return new WaitForSeconds(waitTime);
            }
    }

    private void OnDrawGizmos()
    {
        Vector3 startOffset = transform.forward * offsetDistance;
        Vector3 startOffset2 = -transform.forward * offsetDistance;

        lookDraw(startOffset);
        listenigDraw(startOffset2);
    }
    void look(Vector3 startOffset)
    {
        float angleStep = rayAngle / (numberOfRays - 1);

        // Clear the list of previous hits
        hitList.Clear();

        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate direction for each ray
            float angle = (-rayAngle / 2) + (i * angleStep);
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;

            // Adjust the raycast origin
            Vector3 raycastOrigin = transform.position + startOffset + Vector3.up * yOffset;

            // Create and draw the ray
            Ray ray = new Ray(raycastOrigin, direction * range);

            // Check for collisions and add to hitList if there's a hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                hitList.Add(hit);
            }
        }

        // Handle hits
        bool playerHit = false;
        foreach (RaycastHit hit in hitList)
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerHit = true;
                vendoPlayer = true;
                break;
            }

        }
        if (!playerHit)
        {
            Vector3 startOffset2 = -transform.forward * offsetDistance;
            listenig(startOffset2);
        }
    }

    void listenig(Vector3 startOffset)
    {
        float angleStep = rayAngle / (numberOfRays - 1);

        // Clear the list of previous hits
        hitList2.Clear();

        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate direction for each ray
            float angle = (-rayAngle / 2) + (i * angleStep);
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * -transform.forward;

            // Adjust the raycast origin
            Vector3 raycastOrigin = transform.position + startOffset + Vector3.up * yOffset;

            // Create and draw the ray
            Ray ray = new Ray(raycastOrigin, direction * range);

            // Check for collisions and add to hitList if there's a hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                hitList2.Add(hit);
            }
        }
        // Handle hits
        bool playerHit = false;
        foreach (RaycastHit hit in hitList2)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if(player.isRunnig == true)
                {
                    playerHit = true;
                    vendoPlayer = true;
                    break;
                }
            }
        }
        if (!playerHit)
        {
            // Continue com o destino aleatório se o jogador não for encontrado
            vendoPlayer = false;
        }
    }

    void lookDraw(Vector3 startOffset)
    {
        Gizmos.color = Color.red;
        float angleStep = rayAngle / (numberOfRays - 1);

        // Clear the list of previous hits
        hitList.Clear();

        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate direction for each ray
            float angle = (-rayAngle / 2) + (i * angleStep);
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;

            // Adjust the raycast origin
            Vector3 raycastOrigin = transform.position + startOffset + Vector3.up * yOffset;

            // Create and draw the ray
            Ray ray = new Ray(raycastOrigin, direction * range);
            Gizmos.DrawRay(raycastOrigin, direction * range);

            // Check for collisions and add to hitList if there's a hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                hitList.Add(hit);
            }
        }

        // Handle hits
        foreach (RaycastHit hit in hitList)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Gizmos.color = Color.green;
                agent.destination = GameObject.FindWithTag("Player").transform.position;
            }
        }
    }

    void listenigDraw(Vector3 startOffset)
    {
        Gizmos.color = Color.white;
        float angleStep = rayAngle / (numberOfRays - 1);

        // Clear the list of previous hits
        hitList2.Clear();

        for (int i = 0; i < numberOfRays; i++)
        {
            // Calculate direction for each ray
            float angle = (-rayAngle / 2) + (i * angleStep);
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.up) * -transform.forward;

            // Adjust the raycast origin
            Vector3 raycastOrigin = transform.position + startOffset + Vector3.up * yOffset;

            // Create and draw the ray
            Ray ray = new Ray(raycastOrigin, direction * range);
            Gizmos.DrawRay(raycastOrigin, direction * range);

            // Check for collisions and add to hitList if there's a hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                hitList2.Add(hit);
            }
        }

        // Handle hits
        foreach (RaycastHit hit in hitList2)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (player.isRunnig == true)
                {
                    Gizmos.color = Color.green;
                    agent.destination = GameObject.FindWithTag("Player").transform.position;
                }
            }
        }
    }

    IEnumerator MudarDestinoPeriodicamente()
    {
        while (true)
        {
            while (true)
            {
                // Espera pelo tempo especificado
                yield return new WaitForSeconds(tempoEspera);

                if(voltar == true)
                {
                    numRandom --;
                }
                else
                {
                    numRandom++;
                }
                if(numRandom == pontosDeDestino.Count - 1)
                {
                    voltar = true;
                }
                else if(numRandom == 0)
                {
                    voltar = false;
                }               
                print(numRandom);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Luz")
        {
            OnLuz = true;
            Debug.Log("Luz ativada");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Luz")
        {
            OnLuz = false;
            Debug.Log("Luz desativada");
        }
    }
}
