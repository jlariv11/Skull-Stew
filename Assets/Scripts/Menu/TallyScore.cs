using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TallyScore : MonoBehaviour
{

    //red yellow blue green total
    int[] scores;
    public Text[] text;

    // Start is called before the first frame update
    void Start()
    {
        scores = new int[5];
        scores[0] = PlayerPrefs.GetInt("recipes");
        scores[1] = PlayerPrefs.GetInt("correct");
        scores[2] = PlayerPrefs.GetInt("incorrect");
        scores[3] = scores[1] + scores[2];
        scores[4] = Mathf.RoundToInt((((float)scores[1] / scores[3])*100));
        FinalScore();
    }

    void FinalScore()
    {
        text[0].text = "Recipes Completed \t" + scores[0];
        text[1].text = "Correct Skulls \t" + scores[1];
        text[2].text = "Incorrect Skulls \t" + scores[2];
        text[3].text = "Total Skulls \t" + scores[3];
        text[4].text = "Accuracy \t" + scores[4];
    }
}
