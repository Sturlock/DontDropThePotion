using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public Animator ani;
    public HandScript hand;
    public GameObject ingreident;
    public GameObject puff;

    bool made;

    private void Start()
    {
        ani = puff.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand.handIngredient != null && !made)
        {
            switch (hand.handIngredient.GetComponent<IngredientScript>().type)
            {
                case IngredientType.Feather:
                    Instantiate(ingreident, transform.position, transform.rotation);
                    ani.SetTrigger("newIn");
                    made = true;
                    break;
                case IngredientType.EyeBall:
                    Instantiate(ingreident, transform.position, transform.rotation);
                    ani.SetTrigger("newIn");
                    made = true;
                    break;
                case IngredientType.Mushroom:
                    Instantiate(ingreident, transform.position, transform.rotation);
                    ani.SetTrigger("newIn");
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
