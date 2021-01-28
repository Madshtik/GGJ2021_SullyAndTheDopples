using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRb;

    [Header("Variables")]
    public float mySpeed;
    public float myJumpSpeed;

    bool isGrounded;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ///////////Controls player movement////////////
        if (Input.GetKey(KeyCode.W))
        {
            myRb.velocity = new Vector3(0, 0, mySpeed);
            Debug.Log(transform.position);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRb.velocity = new Vector3(-mySpeed, 0, 0);
            Debug.Log(transform.position);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myRb.velocity = new Vector3(0, 0, -mySpeed);
            Debug.Log(transform.position);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myRb.velocity = new Vector3(mySpeed, 0, 0);
            Debug.Log(transform.position);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            myRb.velocity = new Vector3(0, myJumpSpeed, 0);
            Debug.Log(transform.position);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
