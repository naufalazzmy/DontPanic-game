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
        InvokeRepeating("SpawnPowerUp", 0f, 5f);
    }

    public void SpawnPowerUp() {
        if (gm.spawnAllowed) {
            float xPos = Random.Range(-9.5f, 9.5f);
            float yPos = Random.Range(-4.5f, 4.5f);
            bound = new Vector2(xPos, yPos);
            int rand = Random.Range(0, 100);
            if(rand >= 1) {
                int i = Random.Range(0, 100);
                if(i >= 65) {
                    // spawn bomb
                    Instantiate(Karantina, bound, transform.rotation); 
                    //objectPooler.Instance.SpawnFromPool("karantina", bound, Quaternion.identity);
                } else {
                    Instantiate(Olahraga, bound, transform.rotation);
                    // spawn projectile

                }
            }
        }
        
    }
}
