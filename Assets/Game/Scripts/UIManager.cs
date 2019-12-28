using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public int score;

    public GameObject titleScreen;
    public GameObject gameOverText;
    public GameObject mainFish;
    public GameObject bottomCoral;
    public GameObject topCoral;

    public bool gameOver = true;

    public void Start()
    {
        gameOverText.SetActive(false);
    }

    public void Update()
    {
        if (gameOver)
        {
            if (!gameOverText.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(mainFish, new Vector3(-3, 0, 0), Quaternion.identity);
                    gameOver = false;
                    HideTitleScreen();
                }
            }
            score = 0;
        }
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOverText()
    {
        gameOverText.SetActive(true);
        StartCoroutine(WaitThreeSeconds());
    }

    public void HideGameOverText()
    {
        gameOverText.SetActive(false);
        ShowTitleScreen();
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score: 0";
    }

    // https://forum.unity.com/threads/how-can-i-make-a-c-method-wait-a-number-of-seconds.61011/#post-391085
    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(3.0f);
        HideGameOverText();
    }
    
}
