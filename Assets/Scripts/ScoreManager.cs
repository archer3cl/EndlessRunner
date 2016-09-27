﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("HighScore")) {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        pointsPerSecond = 5;
        scoreIncreasing = true;        
	}
	
	// Update is called once per frame
	void Update () {
        if (scoreIncreasing) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }        
        if (scoreCount > hiScoreCount) {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
    }
}
