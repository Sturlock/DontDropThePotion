using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    
    public HandScript hand;
    public GameObject[] puff;
    public Animator[] ani;

    public GameObject[] objects; 

    bool made;

    private void Awake()
    {
        for(int i = 0; i < puff.Length; i++)
        {
            if(puff[i] != null)
            {
                ani[i] = puff[i].GetComponent<Animator>();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.handIngredient != null && !made)
        {
            GameObject game;
            switch (hand.handIngredient.GetComponent<IngredientScript>().type)
            {
                case IngredientType.Feather:
                    game = Instantiate(hand.handIngredient, objects[0].transform.localPosition, transform.rotation);
                    ani[0].SetTrigger("newIn");
                    game.transform.localScale = Vector3.one;
                    made = true;
                    break;
                case IngredientType.EyeBall:
                    game = Instantiate(hand.handIngredient, objects[1].transform.localPosition, transform.rotation);
                    ani[1].SetTrigger("newIn");
                    made = true;
                    game.transform.localScale = Vector3.one;
                    break;
                case IngredientType.Mushroom:
                    game = Instantiate(hand.handIngredient, objects[2].transform.localPosition, transform.rotation);
                    ani[2].SetTrigger("newIn");
                    game.transform.localScale = Vector3.one;
                    made = true;
                    break;
                default:
                    return;
            }
        }
        else
        {
            
            return;
        }
    }
}
