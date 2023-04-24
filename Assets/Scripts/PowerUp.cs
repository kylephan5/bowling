using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Image PowerupBar;

    private bool isPowerUp = false;
    private bool isDirectionUp = false;
    public static bool isDone = false;
    private float amtPower = 0.0f;
    private float powerSpeed = 250.0f;
    public static float value = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (isPowerUp && !isDone) {
            PowerActive();
        }
    }

    void PowerActive() {
        //directionup is true
        if (isDirectionUp) {
            amtPower += Time.deltaTime * powerSpeed;
            if (amtPower > 100) {
                isDirectionUp = false;
                amtPower = 100.0f;
            }
        } else {
            amtPower -= Time.deltaTime * powerSpeed;
            if (amtPower < 0) {
                isDirectionUp = true;
                amtPower = 0.0f;
            }
        }

        //update fill
        PowerupBar.fillAmount = amtPower / 125.0f + 0.25f;
        value = PowerupBar.fillAmount / 1.0f * 6000.0f;
    }

    public void StartPowerUp() { //set initial variables
        isPowerUp = true;
        amtPower = 0.0f;
        isDirectionUp = true;
    }

    public void EndPowerUp() {
        isPowerUp = false;
        isDone = true;
    }

    public static float PowerUse() {
        return value;
    }
}
