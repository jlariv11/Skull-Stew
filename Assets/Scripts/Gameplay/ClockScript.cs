using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{

    public float timeRemaining;
    int mins;
    int secs;
    public GameManager gameManager;
    public GameObject[] skulls;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted)
        {
            Countdown();
        }
    }

    private void Countdown()
    {
        if(timeRemaining > 0.0f)
        {
            timeRemaining -= Time.deltaTime;
            mins = Mathf.FloorToInt(timeRemaining / 60);
            secs = Mathf.FloorToInt(timeRemaining % 60);

            string timeText = "";

            if(mins > 9)
            {
                timeText += mins + ":";
            }
            else
            {
                timeText += "0" + mins + ":";
            }
            if(secs > 9)
            {
                timeText += secs.ToString();
            }
            else
            {
                timeText += "0" + secs;
            }

            GetComponent<Text>().text = "Time left " + timeText;

        }
        else
        {
            timeRemaining = 0;
            GetComponent<Text>().text = "Time left 00:00";
            TimeIsUp();
        }
    }

    private void TimeIsUp()
    {
        PlayerPrefs.SetInt("recipes", gameManager.score);
        PlayerPrefs.SetInt("correct", gameManager.correctSkulls);
        PlayerPrefs.SetInt("incorrect", gameManager.incorrectSkulls);
        gameManager.GameOver();
    }

}
