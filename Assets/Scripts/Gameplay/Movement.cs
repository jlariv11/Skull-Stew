using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Variables for movement code
    float horizontal;
    public int speed;
    public GameManager manager;



    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        //Example of Input
        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
        }
        */


        if (!manager.gameStarted)
        {
            return;
        }

        horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontal, 0, 0);
        transform.Translate(direction * Time.deltaTime * speed);


    }
}
