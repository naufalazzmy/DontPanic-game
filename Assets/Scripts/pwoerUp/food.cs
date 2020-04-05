using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour, IPooledObject
{
    //private int value = 2;
    public float speed = 3;
    public bool isMoving = false;
    public GameObject player;

    public GameManager gm;

    public void OnObjectSpawn() {
        isMoving = true;
    }

    private void Update() {
        GetComponent<SpriteRenderer>().color = Color.white;
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bullet") {
           // Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
