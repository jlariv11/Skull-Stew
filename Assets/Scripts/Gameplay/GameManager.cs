using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text scoreText;
    RecipeScript recipeScript;
    public int score;
    public int correctSkulls;
    public int incorrectSkulls;
    public bool gameStarted;
    float spawnCooldown;
    public GameObject freeSkull;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        recipeScript = gameObject.GetComponent<RecipeScript>();
        score = 0;
        correctSkulls = 0;
        incorrectSkulls = 0;
        spawnCooldown = 5;
    }

    public void ResetPosition(Vector3 startPos, GameObject skull)
    {
        var restartPos = new Vector3(Random.Range(-3, 3), startPos.y, startPos.z);
        skull.transform.position = restartPos;
        skull.GetComponent<Rigidbody>().velocity = Vector3.zero;
        skull.GetComponent<Rigidbody>().AddForce(0, Random.Range(1,5), 0, ForceMode.Impulse);

    }

    public void SetGameStarted()
    {
        gameStarted = true;
    }

    public void AddIncorrect(int amount)
    {
        incorrectSkulls += amount;
    }

    public void AddCorrect(int amount)
    {
        correctSkulls += amount;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Recipes Completed: " + score;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void CompleteOrder()
    {
        AddCorrect(GetSkullsLeft());
        AddScore(2);
        recipeScript.MakeOrder();
    }

    public string GetNextSkull()
    {
        foreach (Transform ingredient in recipeScript.ingredientParent.transform)
        {
            Image img = ingredient.gameObject.GetComponent<Image>();
            if (img.sprite != recipeScript.gray && ingredient.gameObject.activeSelf)
            {
                return img.sprite.name;
            }
        }
        AddScore(1);
        recipeScript.MakeOrder();
        return GetNextSkull();
    }

    public int GetSkullsLeft()
    {
        int skulls = 0;
        foreach (Transform ingredient in recipeScript.ingredientParent.transform)
        {
            Image img = ingredient.gameObject.GetComponent<Image>();
            if (img.sprite != recipeScript.gray && ingredient.gameObject.activeSelf)
            {
                skulls++;
            }
        }
        return skulls;
    }

    public void MarkSkullAsComplete(string skull)
    {
        foreach(Transform ingredient in recipeScript.ingredientParent.transform)
        {
            Image img = ingredient.gameObject.GetComponent<Image>();
            if(img.sprite.name == skull && img.sprite != recipeScript.gray)
            {
                img.sprite = recipeScript.gray;
                break;
            }
        }
    }

    private void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if(spawnCooldown <= 0)
        {
            spawnCooldown = 5;
            int chance = Random.Range(0, 5);
            if(chance == 4)
            {
                GameObject go = Instantiate(freeSkull);
                ResetPosition(new Vector3(Random.Range(-3, 3), 2.27f, 0), go);
            }
        }
    }

}
