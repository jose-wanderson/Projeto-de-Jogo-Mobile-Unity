using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public Text scoreText;
    public Text gameOverScoreText;

    public Animator gameOverCanvas;
    public Animator desativarJoystick;

    private int score;

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
        else if(instance!= this)
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()
    {
        gameOverCanvas.SetTrigger("GameOver");
        int record = 0;
        if(GameManager.Instance != null )
        {
            GameManager.Instance.totalPoints += score;
            PlayerPrefs.SetInt("TotalPoints", GameManager.Instance.totalPoints);

            if (score > GameManager.Instance.maxScore)
            {
                GameManager.Instance.maxScore = score;
                PlayerPrefs.SetInt("MaxScore", GameManager.Instance.maxScore);

                PlayGamesManager.instance.PostScore(score);
            }

            record = GameManager.Instance.maxScore;
        }
        gameOverScoreText.text = "MOEDAS: " + score + "\nRecord: " + record;
        desativarJoystick.SetTrigger("DesabilitarJoystick");
    }


    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "MOEDAS: " + score;
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ShowRewardedVideo()
    {
        Rewarded.instance.ShowRewardedAdAutomatically();
    }

}
