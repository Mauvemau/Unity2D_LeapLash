using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private int points;
    [SerializeField]
    private GameObject heart;

    [SerializeField]
    private int heartHP;

    public int ReturnPoints()
    {
        return points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
    }

    private int HeartHealth()
    {
        Npc heartRef = heart.GetComponent<Npc>();

        return heartRef.ReturnHealth();

    }

    private void Awake()
    {
        heartHP = HeartHealth();
        points = 0;
    }

}
