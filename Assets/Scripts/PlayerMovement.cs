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
        
        float clampedX = Mathf.Clamp(transform.position.x, -5, 5);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
