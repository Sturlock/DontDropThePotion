using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand1;
    public GameObject hand2;

    public GameObject handPotion = null;
    public GameObject[] handIngredients;

    public bool isHolding;
    private bool failed = false;

    private void Start()
    {
    }

    private void Update()
    {
        

        if (isHolding && Input.GetKey(KeyCode.G))
        {
            //potion.SetActive(false);
            handPotion.SetActive(true);
        }
        if (isHolding && !Input.GetKey(KeyCode.G))
        {
            failed = true;
        };

        if (failed)
        {
            Rigidbody rb = handPotion.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            handPotion.transform.parent = null;
        }
    }

    public void FindIngredientType(IngredientScript ingredient, IngredientType type)
    {
        switch (type)
        {
            case IngredientType.type1:
                Debug.Log("Word");
                break;

            case IngredientType.type2:
                Debug.Log("Word");
                break;
        }
    }
}