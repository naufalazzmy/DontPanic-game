using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombArea : MonoBehaviour
{
    public  static int itemCount;
    public GameManager gm;
    static int score = 0;

    private void Start() {
        
    }

    private void Update() {
       // Debug.Log("jumlah musuh dalam layar : "+itemCount);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Virus" || collision.tag == "Bakteri") {
            if (collision.gameObject.activeSelf) {
                itemCount++;

                //Debug.Log(itemCount);
            }
            
        }
    }

    // ini salah


    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Virus" || collision.tag == "Bakteri") {
            if (collision.gameObject.activeSelf) {
                itemCount--;

                //Debug.Log(itemCount);
            }

        }
    }

    public void decreaseItemCount() {
        itemCount--;
    }

    public void kaboom() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Virus");
        foreach (GameObject enemy in enemies) {
            enemy.SetActive(false);
            score = score + enemy.GetComponent<Virus>().value;
        }
        GameObject[] bak = GameObject.FindGameObjectsWithTag("Bakteri");
        foreach (GameObject enemy in bak) {
            enemy.SetActive(false);
            score = score + enemy.GetComponent<Virus>().value;
        }
        //Debug.Log("Total bomb score " + score);
        gm.addPoint(score);
        itemCount = 0;
        score = 0;
    }

}

