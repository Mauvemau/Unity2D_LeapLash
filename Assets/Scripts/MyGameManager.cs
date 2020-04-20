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

    [SerializeField]
    private GameObject mainMenu;
    private bool gStart = false;
    [SerializeField]
    private GameoverMenu gameOverMenu;
    private bool gOver = false;

    private int playerLevel = 1;
    private int powerRequired = 100;

    private void SetGameOver()
    {
        gameOverMenu.gameObject.SetActive(true);
        gameOverMenu.SetFinalScore(points);
    }

    private void LevelUp()
    {
        switch (playerLevel)
        {
            case 2:
                powerRequired = 200;
                spawner.SetMaxSpawns(10);
                weapons[4].SetActive(true);
                break;
            case 3:
                powerRequired = 400;
                spawner.SetMaxSpawns(15);
                weapons[0].SetActive(true);
                weapons[3].SetActive(true);
                break;
            case 4:
                powerRequired = 600;
                spawner.SetMaxSpawns(20);
                weapons[1].SetActive(true);
                weapons[2].SetActive(true);
                break;
            case 5:
                powerRequired = 800;
                spawner.SetMaxSpawns(30);
                weapons[5].SetActive(true);
                weapons[6].SetActive(true);
                break;
            case 6:
                powerRequired = 1000;
                spawner.SetMaxSpawns(40);
                weapons[7].SetActive(true);
                weapons[8].SetActive(true);
                break;
            case 7:
                powerRequired = 5000;
                spawner.SetSpawnRate(1f);
                spawner.SetMaxSpawns(100);
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


    private void Update()
    {
        if (!heart && !gOver)
        {
            gOver = true;
            spawner.SetSpawning(false);
            Debug.Log("GameOver.");
            SetGameOver();
        }
        if (Input.GetButtonDown("Jump") && !gStart)
        {
            gStart = true;
            mainMenu.SetActive(false);
            spawner.SetSpawning(true);
        }
    }
}
