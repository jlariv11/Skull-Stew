using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public GameObject[] skulls;
    float timeRemaining;
    public Text countdownText;
    GameManager manager;
    bool ready;

    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        timeRemaining = 3;
        foreach (GameObject skull in skulls)
        {
            skull.GetComponent<Rigidbody>().isKinematic = true;
        }
        countdownText.gameObject.SetActive(true);
        manager = GetComponent<GameManager>();
    }

    public void SetReady()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gameStarted || !ready)
        {
            return;
        }
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 3 && timeRemaining >= 2)
        {
            countdownText.text = "3";
        }
        else if (timeRemaining < 2 && timeRemaining >= 1)
        {
            countdownText.text = "2";
        }else if(timeRemaining < 1 && timeRemaining >= 0)
        {
            countdownText.text = "1";
        }
        else if (timeRemaining < 0 && timeRemaining >= -0.5)
        {
            countdownText.text = "Start";
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            foreach (GameObject skull in skulls)
            {
                skull.GetComponent<Rigidbody>().isKinematic = false;
                manager.SetGameStarted();
            }
        }
    }
}
