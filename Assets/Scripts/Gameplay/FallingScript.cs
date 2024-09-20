using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{

    public Vector3 startPos;
    public int score;
    public GameManager gameManager;
    public GameObject particle;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        this.score = 0;
        this.startPos = this.transform.position;
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Reset")
        {
            Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0));
            if (gameObject.tag == "free")
            {
                Destroy(gameObject);
            }
            else
            {
                gameManager.ResetPosition(startPos, this.gameObject);
            }

        }
    }
}
