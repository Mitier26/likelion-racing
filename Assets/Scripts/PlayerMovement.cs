using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!GameManager.instance.isPlaying) return;
        
        float h  = Input.GetAxis("Horizontal");
        
        rb.velocity = Vector3.right * (h * moveSpeed);
    }
}
