using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;

    public int numberOfRays = 5;
    public float rayAngle = 30f;
    public float yOffset = 1.0f;
    public float offsetDistance = 1.0f;
    public float range = 5;
    private float rangeOriginal;

    private List<RaycastHit> hitList = new List<RaycastHit>();
    private List<RaycastHit> hitList2 = new List<RaycastHit>();

    public Player player;

    void Start()
    {
        rangeOriginal = range;
    }


    void Update()
    {
        
    }


    private void OnDrawGizmos()
    {
        Vector3 startOffset = transform.forward * offsetDistance;
        Vector3 startOffset2 = -transform.forward * offsetDistance;

        look(startOffset); 
        listenig(startOffset2);

    }
    void look(Vector3 startOffset)
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

    void listenig(Vector3 startOffset)
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
                if(player.isRunnig == true)
                {
                    Gizmos.color = Color.green;
                    agent.destination = GameObject.FindWithTag("Player").transform.position;
                }
            }
        }
    }
}
