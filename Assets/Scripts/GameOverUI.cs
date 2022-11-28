using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void MainMenu(){
        QuestionAsking.Question = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        GameManager.isDead = false;
        
        Score.ScoreValue = 0;
    }
    public void Restart()
    {
        QuestionAsking.Question = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.isDead = false;
        
        Score.ScoreValue = 0;
    }
}
