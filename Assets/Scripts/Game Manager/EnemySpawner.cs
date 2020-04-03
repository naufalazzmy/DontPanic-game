using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gm;

    public Vector2 topBound;
    public Vector2 leftBound;
    public Vector2 rightBound;
    public Vector2 botBound;

    objectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = objectPooler.Instance;
        gm.spawnAllowed = true;
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }

    void SpawnEnemy() {
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
                if(i >= 40) {
                    objectPooler.Instance.SpawnFromPool("Bakteri", topBound, Quaternion.identity);
                   // Debug.Log("Spawn bakteri on top");
                } else {
                    objectPooler.Instance.SpawnFromPool("Virus", topBound, Quaternion.identity);
                   // Debug.Log("Spawn Virus on Top");
                }
            }

            // spawn on left
            if (rand == 1) {
                float xPos = Random.Range(-11f, -12f);
                float yPos = Random.Range(-5f, 5f);
                leftBound = new Vector2(xPos, yPos);
                int i = Random.Range(0, 100);
                if (i >= 40) {
                    objectPooler.Instance.SpawnFromPool("Bakteri", leftBound, Quaternion.identity);
                   // Debug.Log("Spawn Bakteri on left");
                } else {
                    objectPooler.Instance.SpawnFromPool("Virus", leftBound, Quaternion.identity);
                   // Debug.Log("Spawn Virus on left");
                }

            }
            // spawn on right
            if (rand == 2) {
                float xPos = Random.Range(11f, 12f);
                float yPos = Random.Range(-5, 5);
                rightBound = new Vector2(xPos, yPos);

                int i = Random.Range(0, 100);
                if (i >= 40) {
                    objectPooler.Instance.SpawnFromPool("Bakteri", rightBound, Quaternion.identity);
                   // Debug.Log("Spawn bakteri on right");
                } else {
                    objectPooler.Instance.SpawnFromPool("Virus", rightBound, Quaternion.identity);
                   // Debug.Log("Spawn Virus on right");
                }
            }
            //spawn on bot
            if (rand == 3) {
                float xPos = Random.Range(-10f, 10f);
                float yPos = Random.Range(-6.5f, -7.5f);
                botBound = new Vector2(xPos, yPos);

                int i = Random.Range(0, 100);
                if (i >= 40) {
                    objectPooler.Instance.SpawnFromPool("Bakteri", botBound, Quaternion.identity);
                   // Debug.Log("Spawn bakteri on bot");
                } else {
                    objectPooler.Instance.SpawnFromPool("Virus", botBound, Quaternion.identity);
                   // Debug.Log("Spawn Virus on bot");
                }
            }
        }
    }


}
