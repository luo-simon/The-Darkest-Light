using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    [SerializeField] private float score;

    void Start()
    {
        score = 0;
        if(PlayerPrefs.HasKey("highscore") == false)
            PlayerPrefs.SetInt("highscore", (int) score);

        hiScoreText.text = "HI-SCORE: " + PlayerPrefs.GetInt("highscore");

    }
    
    void Update()
    {
        if (scoreText == null)
            return;


        scoreText.text = "SCORE: " + (int) score;
        score += Time.deltaTime;
        if ((int)score > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", (int)score);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
