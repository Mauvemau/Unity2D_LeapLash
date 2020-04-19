using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private int hitpoints = 30;
    [SerializeField]
    private int pointsWorth = 25;
    [SerializeField] 
    private GameObject[] drops; //Made for later.

    //Audio
    [SerializeField]
    private AudioClip hitSound;
    [SerializeField]
    private float vol = 0.3f;

    private AudioSource source;
    private MyGameManager gm;
    private int currentHealth;

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            if (drops.Length >= 1)
            {
                int drop = Random.Range(0, drops.Length - 1);
                Instantiate(drops[drop]);
            }
            gm.AddPoints(pointsWorth);
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            currentHealth = hitpoints;
            Debug.Log(gameObject.transform.name + " died!");
            this.gameObject.SetActive(false);
        }
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        source.PlayOneShot(hitSound, vol);
        Debug.Log(gameObject.transform.name + " received " + amount + " damage!");
        CheckIfDead();
    }

    public int ReturnHealth()
    {
        return currentHealth;
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<MyGameManager>();
        currentHealth = hitpoints;
    }

}
