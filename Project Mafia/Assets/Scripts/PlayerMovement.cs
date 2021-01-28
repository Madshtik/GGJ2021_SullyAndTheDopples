using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;

    public LayerMask groundMask;

    [Header("Public Variables")]
    public float mySpeed;
    public float jumpHeight;
    public float gravity;
    public float groundDistance;

    Vector3 velocity;

    bool isGrounded;

    float x;
    float z;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 myMovement = transform.right * x + transform.forward * z;

        controller.Move(myMovement * mySpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        controller.Move(velocity * Time.deltaTime); //handles moving

        velocity.y += gravity * Time.deltaTime; //handles falling
    }
}
