using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 2f;
    public float velocity = 1f;
    public float turningSpeed = 200f;

    private CharacterController controller;
    private Vector3 direction;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Time.deltaTime * turningSpeed * Vector3.down);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Time.deltaTime * turningSpeed * Vector3.up);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);

        Vector3 movement = speed * (Time.deltaTime * velocity) * transformDirection;
        direction = new Vector3(movement.x, direction.y, movement.z);

        if (controller.isGrounded)
        {
            direction.y = 0f;
        } else
        {
            direction.y -= gravity * (Time.deltaTime * velocity);
        }

        controller.Move(direction);
    }
}