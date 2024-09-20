using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFallingScript : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Reset")
        {
            Destroy(gameObject);
        }
    }
}
