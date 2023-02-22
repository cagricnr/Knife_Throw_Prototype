using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knifePrefab; //olusacak bicak
    public Transform spawnPoint;
    private Text scoreText;
    private int score;
    private int bestScore;
    private Text bestScoreText;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    private void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>(); //text i instance ettik
        bestScoreText = GameObject.Find("Best Score Text").GetComponent<Text>();

    }

    public void SpawnKnife()
    {
        GameObject go = Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation); //bicak olustu
        go.transform.parent = spawnPoint; // hiyerarside bunun altinda olussun
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " +score.ToString();

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }


}
