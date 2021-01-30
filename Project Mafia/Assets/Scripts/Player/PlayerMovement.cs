using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform myCamera;
    public Transform groundCheck;

    public LayerMask groundMask;

    [Header("Public Variables")]
    public float gravity;
    public float groundDistance;
    public float jumpHeight;
    public float mySpeed;
    public float turnSmoothTime;

    Vector3 velocity;

    bool isGrounded;

    float turnSmoothVelocity;
    float x;
    float z;

    void Update()
    {
        //handles moving
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 myMovement = new Vector3(x, 0, z).normalized;

        if (myMovement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(myMovement.x, myMovement.z) * Mathf.Rad2Deg + myCamera.eulerAngles.y; //uses formula - theta = tan2(x/z) for unity obj rotation & myCamera used to rotate obj to cam rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smoothing rotation of character

            transform.rotation = Quaternion.Euler(0, angle, 0);//actual rotation

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward; //move in direction of the camera
            controller.Move(moveDirection.normalized * mySpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump")) //handles jumping
        {
            Jump(jumpHeight);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; //handles falling
    }

    public void Jump(float thisJumpHeight)
    {
        if (isGrounded) //handles jumping
        {
            velocity.y = Mathf.Sqrt(thisJumpHeight * -2 * gravity); //using formula v^2 = h x 2g
        }
    }
}
