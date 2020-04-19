using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Setup
    [SerializeField]
    private string poolName;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float bulletSpeed;
    //--
    private float bulletDelay;

    private void Shoot()
    {
        PoolManager.Instance().UpdatePosition(poolName, this.transform);
        PoolManager.Instance().CreateObject(poolName);
        PoolManager.Instance().ShootBullet(poolName, transform.up, bulletSpeed);
    }
    private void Awake()
    {
        if (poolName == null)
        {
            poolName = "Default";
        }
        if (fireRate <= 0)
        {
            fireRate = 0.5f;
        }
        if (bulletSpeed <= 0)
        {
            bulletSpeed = 200;
        }
        bulletDelay = 2;
    }

    private void Update()
    {
        //transform.Rotate(0, 0, 720 * Time.deltaTime); Rotation applied on another script

        bulletDelay -= Time.deltaTime;

        if (bulletDelay <= 0)
        {
            Shoot();
            bulletDelay = 0;
            bulletDelay += fireRate;
        }
    }
}
