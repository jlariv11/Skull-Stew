using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCompleterScript : MonoBehaviour
{

    Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue };
    public Material mat;
    float timeBetweenSwitch;
    float timeBetweenSwitchStart;
    int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSwitch = 0.5f;
        timeBetweenSwitchStart = timeBetweenSwitch;
        colorIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenSwitch -= Time.deltaTime;
        if(timeBetweenSwitch <= 0)
        {
            timeBetweenSwitch = timeBetweenSwitchStart;
            mat.color = colors[colorIndex];
            colorIndex++;
            if(colorIndex >= colors.Length)
            {
                colorIndex = 0;
            }
        }
    }
}
