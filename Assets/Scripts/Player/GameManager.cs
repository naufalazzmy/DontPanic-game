using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator gameOverAnimator;
    public Text Score;
    public Text ScoreText;
    public Text HigScoretext;
    public Text Health;
    public GameObject NewIndicator;

    public GameObject x1;
    public GameObject x2;
    public GameObject x3;
    public GameObject x4;
    public GameObject x5;

    public GameObject GameOverUI;

    public Player player;
    public EnemySpawner enemyspawner;
    public cameraShake camerashake;

    public bool spawnAllowed = true;
    public static int  points = 0;
    public static int scoreMultplier = 0;
    public int highScore;

    private bool phase1, phase2, phase3, phase4, phase5, phase6, phase7, phase8 = false;
    public static bool exiter = false;

    private void Start() {
        if (!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetInt("HighScore",0);
            highScore = 0;
        } else {
          highScore = PlayerPrefs.GetInt("HighScore");
        }
        points = 0;
        scoreMultplier = 0;
    }

    public void setExiter() {
        exiter = false;
    }

    public void exiterTrue() {
        //Debug.Log("exitter true");
        exiter = true;
    }
  
    private void shakeCamera() {
        StartCoroutine(camerashake.Shake(.15f, .4f));

    }
    private void Update() {
        
        if (exiter) {
            //Debug.Log("Game Over");
            spawnAllowed = false;
            shakeCamera();
            
            if(points > highScore) {
                highScore = points;
                PlayerPrefs.SetInt("HighScore", highScore);
                NewIndicator.SetActive(true);
            }

            gameOverAnimator.SetTrigger("isOver");
            //GameOverUI.SetActive(true);
        }

        ScoreText.text = points.ToString();
        Score.text = points.ToString();
        HigScoretext.text = PlayerPrefs.GetInt("HighScore").ToString();


        Health.text =  player.getHealth().ToString();

        if (points > 50 && !phase1) {
            enemyspawner.decreaseSpawnInterval();
            phase1 = true;
        } else if (points > 100 && !phase2) {
            enemyspawner.decreaseSpawnInterval();
            phase2 = true;
        } else if (points > 140 && !phase3) {
            enemyspawner.decreaseSpawnInterval();
            phase3 = true;
        } else if (points > 180 && !phase4) {
            enemyspawner.decreaseSpawnInterval();
            phase4 = true;
        } else if (points > 230 && !phase5) {
            enemyspawner.decreaseSpawnInterval();
            phase5 = true;
        } else if (points > 280 && !phase6) {
            enemyspawner.decreaseSpawnInterval();
            phase6 = true;
        } else if (points > 420 && !phase7) {
            enemyspawner.decreaseSpawnInterval();
            phase7 = true;
        } else if (points > 550 && !phase8) {
            enemyspawner.decreaseSpawnInterval();
            phase8 = true;
        }


        if (scoreMultplier == 0) {
            x1.SetActive(false);
            x2.SetActive(false);
            x3.SetActive(false);
            x4.SetActive(false);
            x5.SetActive(false);
        } else if (scoreMultplier == 1) {
            x1.SetActive(true);
            x2.SetActive(false);
            x3.SetActive(false);
            x4.SetActive(false);
            x5.SetActive(false);
        } else if (scoreMultplier == 2) {
            x1.SetActive(false);
            x2.SetActive(true);
            x3.SetActive(false);
            x4.SetActive(false);
            x5.SetActive(false);
        } else if (scoreMultplier == 3) {
            x1.SetActive(false);
            x2.SetActive(false);
            x3.SetActive(true);
            x4.SetActive(false);
            x5.SetActive(false);
        } else if (scoreMultplier == 4) {
            x1.SetActive(false);
            x2.SetActive(false);
            x3.SetActive(false);
            x4.SetActive(true);
            x5.SetActive(false);
        } else if (scoreMultplier == 5) {
            x1.SetActive(false);
            x2.SetActive(false);
            x3.SetActive(false);
            x4.SetActive(false);
            x5.SetActive(true);
        }
    }

  

    // DISINI FI
    public void addPoint(int value) {
        enemyspawner = GameObject.Find("GameManager").GetComponent<EnemySpawner>();
        if(scoreMultplier == 0) {
            points++;
        } else {
            points = points + (value * scoreMultplier);
        }
        
        //edit spawn rate here
        
    }

    public void addMultiplier() {
        if(scoreMultplier < 5) {
            scoreMultplier++;
        }else if(scoreMultplier == 5) {
            scoreMultplier = 5;
        } else {
            return;
        }
    }

    public void resetMultiplier() {
        scoreMultplier = 0;
    }
}
