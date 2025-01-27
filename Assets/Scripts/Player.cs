using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody PlayerRb;
    [SerializeField] float PlayerJumpForce;

    public LayerMask groundLayer; // Assign this in the Inspector
    public Transform groundCheckPoint; // The point to check from (e.g., feet)
    public float groundCheckRadius = 0.2f; // Radius for ground detection

    public bool isGrounded;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);

        Debug.DrawRay(groundCheckPoint.position, Vector3.down * groundCheckRadius, Color.red);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            PlayerRb.AddForce(Vector3.up * PlayerJumpForce, ForceMode.Impulse);
        }
       
    }


}
