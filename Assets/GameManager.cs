using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Move the ball
    Ball b;
    public GameObject ball;
    int score = 0;
    int turnCounter = 0;
    GameObject[] pins;
    bool throwdone = false;
    public Text ScoreUI;
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Camera thirdCamera;
    public Image PowerupBar;
    public Image PowerupBackground;
    public Button PauseButton;
    public HighScore highScore;
    public GameObject menu;



    Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pins");
        positions = new Vector3[pins.Length];
        b = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();

        for (int i=0; i < pins.Length; i++) {
            positions[i] = pins[i].transform.position;
        }
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        if ((ball.transform.position.z > 10) || (ball.transform.position.z > 9 && ball.GetComponent<Rigidbody>().velocity.magnitude < 0.3) || (ball.GetComponent<Rigidbody>().velocity.magnitude < 0.1 && ball.transform.position.z > 0)) {
            CountPinsDown();
            turnCounter++;
            ResetPins();
            ResetCamera();
            PowerUp.isDone = false;
            throwdone = false;
            PowerupBar.fillAmount = 0;
        }

        if (Input.GetKey("c")) {
            SwitchCamera();
        }

        if (turnCounter == 10) {
            menu.SetActive(true);
        }
    }

    void MoveBall() {
        Vector3 position = ball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -.6f, .6f);
        ball.transform.position = position;
        //ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    public void Throw() {
        if (!throwdone) {
            b.Throw(PowerUp.PowerUse());
        }
        throwdone = true;
    }

    void CountPinsDown() {
        for (int i=0; i < pins.Length; i++) {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf) {
                score++;
                pins[i].SetActive(false);
            }
        }
        ScoreUI.text = score.ToString();

        if (score > highScore.highScore) {
            highScore.highScore = score;
        }
    }

    void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++) {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }

        ball.transform.position = new Vector3(0, 0.108f, -9f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }

    void ResetCamera()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.GetComponent<AudioListener>().enabled  =  true;
        secondaryCamera.gameObject.SetActive(false);
        secondaryCamera.GetComponent<AudioListener>().enabled  =  false;
        thirdCamera.gameObject.SetActive(false);
        thirdCamera.GetComponent<AudioListener>().enabled  =  false;
        PowerupBar.gameObject.SetActive(false);
        PowerupBackground.gameObject.SetActive(false);
    }

    void SwitchCamera()
    {
        if (mainCamera.GetComponent<AudioListener>().enabled) {
            thirdCamera.gameObject.SetActive(true);
            thirdCamera.GetComponent<AudioListener>().enabled  =  true;
            secondaryCamera.gameObject.SetActive(false);
            secondaryCamera.GetComponent<AudioListener>().enabled  =  false;
            mainCamera.gameObject.SetActive(false);
            mainCamera.GetComponent<AudioListener>().enabled  =  false;
        } else {
            mainCamera.gameObject.SetActive(true);
            mainCamera.GetComponent<AudioListener>().enabled  =  true;
            secondaryCamera.gameObject.SetActive(false);
            secondaryCamera.GetComponent<AudioListener>().enabled  =  false;
            thirdCamera.gameObject.SetActive(false);
            thirdCamera.GetComponent<AudioListener>().enabled  =  false;
        }
    }

    public void Pause() {
        menu.SetActive(true);
        PauseButton.enabled = false;
    }
    
}
