using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text TextDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject changeSceneButton;

    private void Start() {
        StartCoroutine(Type());
    }

    private void Update() {
        
        if (TextDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
        if(TextDisplay.text == sentences[12]) {
            continueButton.SetActive(false);
            changeSceneButton.SetActive(true);
        }
    }

    IEnumerator Type() {
        foreach(char letter in sentences[index].ToCharArray()) {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1) {
            index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        } else {
            TextDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    public void keMainMenu() {
        Debug.Log("kemain menu");
    }
}
