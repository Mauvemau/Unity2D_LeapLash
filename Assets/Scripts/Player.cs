using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Welcome to Ihavenoideawhatimdoing.cs
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float forceDelay;

    private float forceTime;

    private Vector3 vectorDirector;
    private Vector3 targetPosition;

    private void Movement()
    {
        targetPosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition) - transform.position;
        targetPosition.z = 0;

        rb.AddForce(targetPosition * speed);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (speed <= 0)
        {
            speed = 10f;
        }
        if(forceDelay <= 0)
        {
            forceDelay = 0.1f;
        }
    }
    void Update()
    {
        forceTime -= Time.deltaTime;
        if (Input.GetButton("Fire1") && forceTime <= 0)
        {
            Movement();
            forceTime = 0;
            forceTime += forceDelay;
        }
    }
}
