using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweUpSpawner : MonoBehaviour
{
    public GameManager gm;

    public GameObject Karantina;
    public GameObject Olahraga;

    private Vector2 bound;
    void Start() {
        InvokeRepeating("SpawnPowerUp", 0f, 10f);
    }

    public void SpawnPowerUp() {
        if (gm.spawnAllowed) {
            float xPos = Random.Range(-9.5f, 9.5f);
            float yPos = Random.Range(-4.5f, 4.5f);
            bound = new Vector2(xPos, yPos);
            int rand = Random.Range(0, 100);
            //Debug.Log(rand);
            if(rand >= 70) {
                Instantiate(Karantina, bound, transform.rotation);
            } else {
                return;
            }
        }
        
    }
}
