using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBarScript : MonoBehaviour
{
    public float timeRemaining;
    float startTime;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        startTime = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameStarted)
        {
            return;
        }
        timeRemaining -= Time.deltaTime;
        int timeScaledWidth = Mathf.RoundToInt((timeRemaining * 500) / startTime);
        int timeScaledX = Mathf.RoundToInt((timeRemaining * 150) / startTime);
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timeScaledWidth);
        //rect.SetPositionAndRotation(new Vector3(timeScaledX, 152, 0), rect.rotation);
        //rect.localPosition = new Vector3(timeScaledX, 152, 0);
        if(timeRemaining <= 0)
        {
            TimeIsUp();
        }

    }

    private void TimeIsUp()
    {
        PlayerPrefs.SetInt("recipes", manager.score);
        PlayerPrefs.SetInt("correct", manager.correctSkulls);
        PlayerPrefs.SetInt("incorrect", manager.incorrectSkulls);
        manager.GameOver();
    }
}
