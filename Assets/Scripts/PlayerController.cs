using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float torque = 1f;
    Rigidbody2D rb2d;
    [SerializeField]
    float boostSpeed = 10f;
    float boostUpSpeed = 0f;
    SurfaceEffector2D effector2d;
    [SerializeField]
    float slowSpeed = 10f;
    float boostDownSpeed = 0f;
    [SerializeField]
    float normalSpeed = 20f;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        EnableControls();
        rb2d = GetComponent<Rigidbody2D>();
        effector2d = FindObjectOfType<SurfaceEffector2D>();
        boostUpSpeed = normalSpeed + boostSpeed;
        boostDownSpeed = normalSpeed - slowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            effector2d.speed = boostUpSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            effector2d.speed = boostDownSpeed;
        }
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) 
        {
            effector2d.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torque);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torque);
        }
    }

    public void DisableControls()
    {
        canMove = false;
        Debug.Log($"disabled {canMove}");
    }
    public void EnableControls()
    {
        canMove = true;
        Debug.Log($"enabled {canMove}");
    }
}
