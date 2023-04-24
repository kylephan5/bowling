using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Button PauseButton;

    public void ResetGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu() {
        SceneManager.LoadScene("LobbyScene");
    }

    public void Continue() {
        menu.SetActive(false);
        PauseButton.enabled = true;
    }

    void Update() {
        #if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Escape)) {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        #endif
    }

}
