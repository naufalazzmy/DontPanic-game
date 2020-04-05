using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public Animator tutIU;
    public GameObject slideTerakhir;
    public GameObject close;
    public GameObject nextButton;

    public void nextSlide() {
        tutIU.SetTrigger("next");
        Debug.Log("next!");
    }

    public void closeTutorial() {
        Debug.Log("Ganti ke scene main game");
    }

    private void Update() {
        if (slideTerakhir.gameObject.activeSelf) {
            close.SetActive(true);
            nextButton.SetActive(false);
        }
    }

}
