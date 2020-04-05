using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManajmenGame : MonoBehaviour
{
    public void ExitGame() {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void mainLagi() {
        SceneManager.LoadScene("Game");
        Debug.Log("main lagi");
    }

}
