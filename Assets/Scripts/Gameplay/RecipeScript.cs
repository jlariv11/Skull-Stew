using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeScript : MonoBehaviour
{
    //yellow blue green red
    public Sprite[] skullSprites;
    public GameObject ingredientParent;
    public Sprite gray;

    // Start is called before the first frame update
    void Start()
    {
        MakeOrder();
    }

    public void MakeOrder()
    {
        foreach(Transform child in ingredientParent.transform)
        {
            child.gameObject.SetActive(true);
        }
        int recipeLength = Random.Range(3, 6);
        Sprite[] recipe = new Sprite[recipeLength];
        for(int i = 0; i < recipeLength; i++)
        {
            recipe[i] = skullSprites[Random.Range(0, skullSprites.Length - 1)];
        }
        for(int i = 0; i < recipeLength; i++)
        {
            Image image = ingredientParent.transform.GetChild(i).GetComponent<Image>();
            image.sprite = recipe[i];
        }
        for(int i = recipeLength; i < 5; i++)
        {
            ingredientParent.transform.GetChild(i).gameObject.SetActive(false);
        }

    }



}
