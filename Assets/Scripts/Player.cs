using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Welcome to Ihavenoideawhatimdoing.cs
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float boostSpeed;
    [SerializeField]
    private float forceDelay = 0.1f;
    [SerializeField]
    private float boostCooldown;

    private float forceTime = 0;
    private float boostTimer = 0;

    private Vector3 vectorDirector;
    private Vector3 targetPosition;

    private void Movement(float impulse)
    {
        targetPosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition) - transform.position;
        targetPosition.z = 0;

        rb.AddForce(targetPosition * impulse);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        forceTime -= Time.deltaTime;
        boostTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && forceTime <= 0)
        {
            Movement(speed);
            forceTime = forceDelay;
        }
        if (Input.GetButtonDown("Fire2") && boostTimer <= 0)
        {
            Movement(boostSpeed);
            boostTimer = boostCooldown;
        }
    }
}
