using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    public float speed = 3;
    public bool isMoving = false;
    public GameObject player;

    public void OnObjectSpawn() {
        isMoving = true;
        //float xforce = Random.Range(-1.0f, 1.0f);
        //float yforce = Random.Range(-1.0f, 1.0f);

        //Vector2 force = new Vector2(xforce, yforce);

        //GetComponent<Rigidbody2D>().velocity = force;
    }

    private void Update() {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

}
