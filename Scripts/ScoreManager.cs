using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    // Use this for initialization

    public Text scoreText;
    public float scoreCount = 0;
    //public static int highscore;
    //public Text highScoreText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //PlayerPrefs.SetInt("HighScore", scoreCount);
        scoreText.text = "Score: " + Score.score;
        //Debug.Log(scoreCount);

    }
}
public static class Score
{
    public static int score;
   // public Text scoreText;



}