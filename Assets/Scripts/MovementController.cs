using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform m_WallCheck;

    public PlayerController controller;

    // Start is called before the first frame update
    public float runSpeed = 20f;
    float horizontalMove = 0f;
    int direction = 1;
    bool isJumping = false;

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_WallCheck.position, 0.1f, controller.m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                direction *= -1;
                break;
            }
        }

        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = direction * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping); // move player

        isJumping = false;
    }
}
