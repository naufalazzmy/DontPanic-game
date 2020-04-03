using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static bool spawnAllowed;

    public Vector2 topBound;
    public Vector2 leftBound;
    public Vector2 rightBound;
    public Vector2 botBound;

    objectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = objectPooler.Instance;
        spawnAllowed = true;
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }

    void SpawnEnemy() {
        if (spawnAllowed) {
            int rand = Random.Range(0, 4);
            //Debug.Log(rand);
            // spawn on top
            if (rand == 0) {
                float xPos = Random.Range(-10f, 10f);
                float yPos = Random.Range(6.5f, 7.5f);
                topBound = new Vector2(xPos, yPos);
                objectPooler.Instance.SpawnFromPool("Virus", topBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Bakteri", topBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Food", topBound, Quaternion.identity);
                //Debug.Log("spawn TOP");
            }
            // spawn on left
            if (rand == 1) {
                float xPos = Random.Range(-11f, -12f);
                float yPos = Random.Range(-5f, 5f);
                leftBound = new Vector2(xPos, yPos);
                objectPooler.Instance.SpawnFromPool("Virus", leftBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Bakteri", leftBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Food", leftBound, Quaternion.identity);
                // Debug.Log("spawn LEFT");
            }
            // spawn on right
            if (rand == 2) {
                float xPos = Random.Range(11f, 12f);
                float yPos = Random.Range(-5, 5);
                rightBound = new Vector2(xPos, yPos);
                objectPooler.Instance.SpawnFromPool("Virus", rightBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Bakteri", rightBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Food", rightBound, Quaternion.identity);
                //Debug.Log("spawn RIGHT");
            }
            //spawn on bot
            if (rand == 3) {
                float xPos = Random.Range(-10f, 10f);
                float yPos = Random.Range(-6.5f, -7.5f);
                botBound = new Vector2(xPos, yPos);
                objectPooler.Instance.SpawnFromPool("Virus", botBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Bakteri", botBound, Quaternion.identity);
                objectPooler.Instance.SpawnFromPool("Food", botBound, Quaternion.identity);
                //Debug.Log("spawn BOT");
            }
        }
    }


}
