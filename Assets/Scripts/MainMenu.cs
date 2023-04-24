using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    void Update() {
        #if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        #endif
    }

    public void QuitGame() {
        Application.Quit();
    }
}
