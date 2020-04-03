﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCommer : MonoBehaviour, IPooledObject
{
    public int score = 10;
    public float speed = 3;
    public bool isMoving = false;
    public GameObject player;

    public GameManager gm;

    public void OnObjectSpawn() {
        isMoving = true;
    }

    private void Update() {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet") {
            gm.addPoint(score);
            this.gameObject.SetActive(false);
        }
    }

}