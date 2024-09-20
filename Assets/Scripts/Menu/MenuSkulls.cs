using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkulls : MonoBehaviour
{

    public GameObject[] skulls;
    float shootTime;
    float startShootTime;
    GameObject currentSkull;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = 0.5f;
        startShootTime = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        shootTime -= Time.deltaTime;

        if(shootTime <= 0)
        {
            shootTime = startShootTime;
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            currentSkull = Instantiate(skulls[Random.Range(0, skulls.Length)], spawnPos, Quaternion.Euler(0, 180, 0));
            currentSkull.GetComponent<Rigidbody>().useGravity = true;
            currentSkull.GetComponent<Rigidbody>().velocity = Vector3.zero;
            currentSkull.GetComponent<Rigidbody>().AddForce(Random.Range(-3, 3), 5, Random.Range(-3, 3), ForceMode.Impulse);
        }

    }
}
