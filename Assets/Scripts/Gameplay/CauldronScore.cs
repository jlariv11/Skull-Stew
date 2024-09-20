using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronScore : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] skullScores;
    public string chosenSkull;
    public AudioClip[] clips;
    AudioSource source;
    GameObject stuffedSkull;
    public GameObject fillParticle;
    GameObject particleInstance;
    public GameObject fullText;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        chosenSkull = gameManager.GetNextSkull();
        stuffedSkull = null;
    }

    void OnTriggerEnter(Collider col)
    {
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);

        if (col.gameObject.tag == chosenSkull) {
            gameManager.MarkSkullAsComplete(chosenSkull);
            chosenSkull = gameManager.GetNextSkull();
            gameManager.AddCorrect(1);
            gameManager.ResetPosition(col.gameObject.GetComponent<FallingScript>().startPos, col.gameObject);
        }else if(col.gameObject.tag == "free")
        {
            gameManager.CompleteOrder();
            chosenSkull = gameManager.GetNextSkull();
        }
        else
        {
            gameManager.AddIncorrect(1);
            stuffedSkull = col.gameObject;
            particleInstance = Instantiate(fillParticle, transform);
            fullText.SetActive(true);
        }
    }

    public bool IsStuffed()
    {
        return stuffedSkull != null;
    }

    public void Launch()
    {
        stuffedSkull.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        stuffedSkull.GetComponent<Rigidbody>().AddForce(new Vector3(-3, 5, 0), ForceMode.Impulse);
        stuffedSkull = null;
        Destroy(particleInstance);
        fullText.SetActive(false);
    }


}
