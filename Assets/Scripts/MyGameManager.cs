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

    [SerializeField]
    private GameUI myUI;

    [SerializeField]
    private EnemySpawner spawner;

    private int playerLevel = 1;
    private int powerRequired = 100;

    private void LevelUp()
    {
        switch (playerLevel)
        {
            case 2:
                powerRequired = 200;
                spawner.SetMaxSpawns(10);
                weapons[0].SetActive(true);
                break;
            case 3:
                powerRequired = 300;
                spawner.SetMaxSpawns(15);
                weapons[1].SetActive(true);
                break;
            case 4:
                powerRequired = 400;
                spawner.SetMaxSpawns(30);
                weapons[2].SetActive(true);
                break;
            case 5:
                powerRequired = 666;
                spawner.SetMaxSpawns(40);
                weapons[3].SetActive(true);
                break;
            default:
                Debug.Log("Max level reached.");
                break;
        }
    }

    private void CheckLevelUp()
    {
        if (points >= powerRequired)
        {
            playerLevel++;
            LevelUp();
        }
    }

    public int ReturnPoints()
    {
        return points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        myUI.UpdatePower(points);
        CheckLevelUp();
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
        myUI.UpdatePower(points);
    }

}
