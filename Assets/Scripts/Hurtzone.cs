using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtzone : MonoBehaviour
{

    [SerializeField]
    private float damageDelay = 1.0f;
    [SerializeField]
    private int damage = 0;
    [SerializeField]
    private float range = 0.6f;
    [SerializeField]
    private LayerMask layermask;

    private float damageTimer;

    private void Awake()
    {
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, range, layermask);

            damageTimer -= Time.deltaTime;
            if (hitInfo.collider != null)
            {
                if (damageTimer <= 0)
                {
                    Debug.Log("Hit");
                    if (hitInfo.collider.GetComponent<Npc>())
                    {
                        Npc enemyhit = hitInfo.collider.GetComponent<Npc>();
                        enemyhit.ApplyDamage(damage);
                    }
                    damageTimer = damageDelay;
                }
            }
        }
    }

}
