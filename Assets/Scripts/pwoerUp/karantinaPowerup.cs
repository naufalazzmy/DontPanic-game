using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karantinaPowerup : MonoBehaviour
{

    public Animator flashScreen;
    public bombArea bombarea;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(matikan());
        flashScreen = GameObject.Find("CamAnchor/FlashScreen").GetComponent<Animator>();
        Debug.Log(flashScreen);
    }

    IEnumerator matikan() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet") {
            
            flashScreen.SetTrigger("Boom");
            bombarea.kaboom();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            

            // hancurkan semua bakteri & virus
        }
        if(collision.tag == "Player") {
            Destroy(this.gameObject);
            // do nothing
        }
    }
}
