using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("HighScore"))   // If HighScore has been stored via player prefs on previous playthrough
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore"); // Set high score to any previous highest score
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime; // Add points to score count based points per second x time (if scoreIncreasing is true)
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;    // Sets the new high score = current score count if high score is beaten
            PlayerPrefs.SetFloat("HighScore", highScoreCount);  // Saves value names HighScore - which is highScoreCount
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);    // Print Score: with current player
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);    // Print High Score: with highest current score

	}
}
