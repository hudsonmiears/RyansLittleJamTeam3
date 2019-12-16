using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public float startTime;
    public float timer;

    public float playerWallet = 0;

    // Start is called before the first frame update
    void Awake()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {  
        if (timer <= 0) {
            SceneManager.LoadScene("GameOver");
        }
        timer -= Time.deltaTime;
    }

    public void GoToMainScene() {
        SceneManager.LoadScene("MainScene");
    }
}
