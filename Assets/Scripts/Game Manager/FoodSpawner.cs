using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Vector2 topBound;
    public Vector2 leftBound;
    public Vector2 rightBound;
    public Vector2 botBound;

    objectPooler objectPooler;

    public GameManager gm;
    // Start is called before the first frame update
    void Start() {
        objectPooler = objectPooler.Instance;
        gm.spawnAllowed = true;
        InvokeRepeating("SpawnFood", 0f, 3f);
    }

    void SpawnFood() {
        if (gm.spawnAllowed) {
            int rand = Random.Range(0, 4);
            //Debug.Log(rand);
            // spawn on top
            if (rand == 0) {
                float xPos = Random.Range(-10f, 10f);
                float yPos = Random.Range(6.5f, 7.5f);
                topBound = new Vector2(xPos, yPos);
                // spawn enemy with probability 
                int i = Random.Range(0, 100);
                if (i >= 50) {
                    objectPooler.Instance.SpawnFromPool("Food", topBound, Quaternion.identity);
                } else {
                    
                }
            }

            // spawn on left
            if (rand == 1) {
                float xPos = Random.Range(-11f, -12f);
                float yPos = Random.Range(-5f, 5f);
                leftBound = new Vector2(xPos, yPos);
                int i = Random.Range(0, 100);
                if (i >= 50) {
                    objectPooler.Instance.SpawnFromPool("Food", leftBound, Quaternion.identity);
                } else {

                }

            }
            // spawn on right
            if (rand == 2) {
                float xPos = Random.Range(11f, 12f);
                float yPos = Random.Range(-5, 5);
                rightBound = new Vector2(xPos, yPos);

                int i = Random.Range(0, 100);
                if (i >= 50) {
                    objectPooler.Instance.SpawnFromPool("Food", rightBound, Quaternion.identity);
                } else {

                }
            }
            //spawn on bot
            if (rand == 3) {
                float xPos = Random.Range(-10f, 10f);
                float yPos = Random.Range(-6.5f, -7.5f);
                botBound = new Vector2(xPos, yPos);

                int i = Random.Range(0, 100);
                if (i >= 50) {
                    objectPooler.Instance.SpawnFromPool("Food", botBound, Quaternion.identity);
                } else {

                }
            }
        }
    }
}
