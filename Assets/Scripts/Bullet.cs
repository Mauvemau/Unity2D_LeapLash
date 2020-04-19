using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

    private float lifeTimer;

    private Rigidbody2D rb;


    public void DestroyBullet()
    {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
        lifeTimer = lifeTime;
        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (lifeTime <= 0)
        {
            lifeTime = 2.5f;
        }
        lifeTimer = lifeTime;
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            lifeTimer -= Time.deltaTime;
            transform.Rotate(0, 0, 720 * Time.deltaTime);
        }
        if(lifeTimer <= 0)
        {
            DestroyBullet();
        }
    }


}
