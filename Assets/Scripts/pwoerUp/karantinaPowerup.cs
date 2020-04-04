using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karantinaPowerup : MonoBehaviour
{

    public bombArea bombarea;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(matikan());
    }

    IEnumerator matikan() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet") {
            Destroy(this.gameObject);
            bombarea.kaboom();
            // hancurkan semua bakteri & virus
        }
        if(collision.tag == "Player") {
            Destroy(this.gameObject);
            // do nothing
        }
    }
}
