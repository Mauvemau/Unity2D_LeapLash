using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [SerializeField]
    private float leapDelay;
    [SerializeField]
    private float speed;

    float X, Y;
    private Vector3 direction;
    private Vector3 target;
    private Rigidbody2D rb;
    private Transform origin;
    
    private float leapTimer;

    private void RandomDirections()
    {
        X = Random.Range(origin.position.x - 10, origin.position.x + 10);
        Y = Random.Range(origin.position.y - 10, origin.position.y + 10);
    }

    private void Movement()
    {
        RandomDirections();
        target = new Vector3(X, Y);
        direction = target - transform.position;
        rb.AddForce(direction.normalized * speed);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        origin = this.transform;
        if(leapDelay <= 0)
        {
            leapDelay = 1.5f;
        }
        if(speed <= 0)
        {
            speed = 300f;
        }
        leapTimer = leapDelay;
    }

    private void Update()
    {
        leapTimer -= Time.deltaTime;

        if (leapTimer <= 0)
        {
            Movement();
            leapTimer = leapDelay;
        }

    }

}
