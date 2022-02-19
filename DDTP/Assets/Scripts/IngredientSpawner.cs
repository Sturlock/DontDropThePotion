using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject[] puff;
    public Animator[] ani;

    public GameObject[] objects;

    private bool made;
    

    private void Awake()
    {
        for (int i = 0; i < puff.Length; i++)
        {
            if (puff[i] != null)
            {
                ani[i] = puff[i].GetComponent<Animator>();
            }
        }
        

    }

    // Update is called once per frame
    public void NewIngredient(HandScript hand)
    {
        if (hand.handIngredient != null)
        {
            GameObject game;
            switch (hand.handIngredient.GetComponent<IngredientScript>().type)
            {
                case IngredientType.Feather:
                    game = Instantiate(hand.handIngredient, objects[0].transform.localPosition, transform.rotation);
                    ani[0].SetTrigger("newIn");
                    game.transform.localScale = Vector3.one;

                    break;

                case IngredientType.EyeBall:
                    game = Instantiate(hand.handIngredient, objects[1].transform.localPosition, transform.rotation);
                    ani[1].SetTrigger("newIn");

                    game.transform.localScale = Vector3.one;
                    break;

                case IngredientType.Mushroom:
                    game = Instantiate(hand.handIngredient, objects[2].transform.localPosition, transform.rotation);
                    ani[2].SetTrigger("newIn");
                    game.transform.localScale = Vector3.one;

                    break;

                default:
                    return;
            }
        }
    }
}