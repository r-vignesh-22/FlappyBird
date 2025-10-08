using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    
    public static ScoreHandler instance;
    public Text scoreText;
    public Text uiScoreText;

    
    public int score;
    public int highScore;
    void Awake()
    {
        //singleton
        if (instance != null) Destroy(this);
        instance = this;

        //At start score must be zero
        score = 0;
    }


    public void IncrementScore(int point)
    {
        score += point;
        UpdateUiScore();
    }
    void UpdateUiScore()
    {
        scoreText.text = score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateUiScore();
    }

    //function to calculate the highest score take by player
    public void CalculateHighScore(){
        if(highScore < score){
            highScore = score;
            uiScoreText.text = highScore.ToString();
        }

    }

}
