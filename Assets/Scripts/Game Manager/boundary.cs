using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    public GameManager gm;
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.tag == "Bullet") {
            gm.resetMultiplier();
            Destroy(collision.gameObject);

        }

    }
}
