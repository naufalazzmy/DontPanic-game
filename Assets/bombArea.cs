using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombArea : MonoBehaviour
{

    public  static int itemCount;
    public static bool isBomb = false;



    private void Start() {
        isBomb = false;
    }
    private void Update() {
        Debug.Log("jumlah musuh dalam layar : "+itemCount);
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
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Virus" || collision.tag == "Bakteri") {
            if (isBomb) {
                collision.gameObject.SetActive(false);
                Debug.Log("BOMB!");
                isBomb = false;
            }
               
        }
    }

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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Virus");
        foreach (GameObject enemy in enemies) {
            enemy.SetActive(false);
        }
        GameObject[] bak = GameObject.FindGameObjectsWithTag("Bakteri");
        foreach (GameObject enemy in bak) {
            enemy.SetActive(false);
        }
        itemCount = 0;
        //Debug.Log("jumlah virus: "+enemies.Length);
        isBomb = true;
    }
}

