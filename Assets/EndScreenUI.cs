using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button replayButton;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

        gm.timer = 100000;

        messageText.text = "You earned " + gm.playerWallet + " frogbucks!";

    }

    

    public void LoadMain() {
        SceneManager.LoadScene("MainScene");
    }
}
