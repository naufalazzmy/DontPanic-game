using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool spawnAllowed = true;
    public int points = 0;


    public void addPoint(int value) {
        points += value;

       // Debug.Log(points);
    }
}
