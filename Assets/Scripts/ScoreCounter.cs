using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public GameManager gameManager;
    public Text scorecounter;
    public Text highScoreText;
    public static int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score: " + highScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        scorecounter.text = "Score: " + gameManager.GetScore();
        
        if (gameManager.GetScore() > highScore)
        {
            
            int score = gameManager.GetScore();
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
        }
        
    }

    //int originalHighScore = PlayerPrefs.GetInt("High Score", 0);
    
    public void SaveHighScore()
    {
        // compare current session's high score vs our recorded high score from prefs
       
        int originalHighScore = PlayerPrefs.GetInt("High Score");
        if (highScore > originalHighScore)
        {
            PlayerPrefs.SetInt("High Score", highScore);
        }

    }
   

}
