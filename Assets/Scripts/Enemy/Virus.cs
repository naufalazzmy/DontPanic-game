﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour, IPooledObject
{
    public GameObject blastParticle;

    public bombArea bombarea;
    public int value = 2;
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
            transform.Rotate(0, 0, 300*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet") {
            gm.addMultiplier();
            gm.addPoint(value);
            bombarea.decreaseItemCount();
            Destroy(collision.gameObject);

            blastParticle.transform.position = transform.position;
            Instantiate(blastParticle, transform.position , Quaternion.identity);

            this.gameObject.SetActive(false);

        }
    }

}
