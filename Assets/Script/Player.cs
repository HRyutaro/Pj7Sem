using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    public float rotation = 90;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontalInput * rotation * Time.deltaTime);

        // Direção de movimento do personagem baseada na rotação atual
        Vector3 moveDirection = transform.forward * verticalInput;

        if (Input.GetButton("Fire3")) // correr
        {
            rb.velocity = moveDirection * (speed * 2);
            Debug.Log("correndo");
        }
        else
        {
            rb.velocity = moveDirection * speed;
        }
    }
}
