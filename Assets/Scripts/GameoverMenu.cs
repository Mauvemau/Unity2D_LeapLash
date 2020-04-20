using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverMenu : MonoBehaviour
{

    [SerializeField]
    private Text finalScore;

    public void SetFinalScore(int amount)
    {
        finalScore.text = "" + amount;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        if (!finalScore)
        {
            foreach (Transform t in transform)
            {
                if (t.name == "Score")
                {
                    finalScore = t.GetComponent<Text>();
                }
            }
        }
    }

}
