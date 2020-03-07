using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] private float score;

    void Start()
    {
        score = 0;
    }
    
    void Update()
    {
        scoreText.text = "Score: " + (int) score;
        score += Time.deltaTime;
    }
}
