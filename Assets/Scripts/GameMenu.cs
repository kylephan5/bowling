using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Button PauseButton;
    public GameObject RulesScreen;

    public void ResetGame() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu() {
        SceneManager.LoadScene("LobbyScene");
    }

    public void Rules() {
        RulesScreen.SetActive(true);
    }

    public void Back() {
        RulesScreen.SetActive(false);
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
