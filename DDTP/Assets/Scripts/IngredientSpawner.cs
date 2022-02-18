using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public HandScript hand;
    public GameObject ingreident1;
    public GameObject ingreident2;
    public GameObject ingreident3;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<HandScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hand.handIngredient != null)
        {
            switch (hand.handIngredient.GetComponent<IngredientScript>().type)
            {
                case IngredientType.Mushroom:
                    Instantiate(ingreident1, transform.position, transform.rotation);
                    break;
                case IngredientType.EyeBall:
                    Instantiate(ingreident2, transform.position, transform.rotation);
                    break;
                case IngredientType.Feather:
                    Instantiate(ingreident3, transform.position, transform.rotation);
                    break;
                default:
                    return;
            }
        }
    }
}
