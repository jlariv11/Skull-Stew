using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFillScript : MonoBehaviour
{

    CauldronScore cauldronScript;

    // Start is called before the first frame update
    void Start()
    {

        cauldronScript = transform.GetComponentInParent<CauldronScore>();
    }

    void Update()
    {
        if (cauldronScript.IsStuffed())
        {
            GetComponent<BoxCollider>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<BoxCollider>().enabled = false;
                cauldronScript.Launch();
            }
        }
    }
}
