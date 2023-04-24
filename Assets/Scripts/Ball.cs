using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float power;
    [SerializeField]
    private Image PowerupBar;
    [SerializeField]
    private Image PowerupBackground;
    public Camera mainCamera;
    public Camera secondaryCamera;
    // Start is called before the first frame update

    PowerUp p;
    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        secondaryCamera.GetComponent<AudioListener>().enabled = false;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            PowerupBar.gameObject.SetActive(true);
            PowerupBackground.gameObject.SetActive(true);
        }
    }

    public void Throw(float power) {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        rb.AddForce(Vector3.forward * power);
        mainCamera.gameObject.SetActive(false);
        mainCamera.GetComponent<AudioListener>().enabled  =  false;
        secondaryCamera.gameObject.SetActive(true);
        secondaryCamera.GetComponent<AudioListener>().enabled  =  true;
    }
}
