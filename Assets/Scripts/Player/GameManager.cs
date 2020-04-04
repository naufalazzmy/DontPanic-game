using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool spawnAllowed = true;
    public static int  points = 0;
    public static int scoreMultplier = 0;
    public int highScore;

    private void Update() {
        Debug.Log(points);
    }

    private void Start() {
        points = 0;
        scoreMultplier = 0;
    }

    public void addPoint(int value) {
        points = points + (value*scoreMultplier);
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
