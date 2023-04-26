using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SelectGame;
    public Button Dusk;
    public Button Day;
    public Button Night;
    public Button BackButton;

    void Start() {
        SelectGame.SetActive(false);
    }

    public void StartGame() {
        SelectGame.SetActive(true);
    }

    public void DuskGame() {
        SceneManager.LoadScene("DuskBowling");
    }

    public void DayGame() {
        SceneManager.LoadScene("DayBowling");
    }

    public void NightGame() {
        SceneManager.LoadScene("NightBowling");
    }

    public void Back() {
        SelectGame.SetActive(false);
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
