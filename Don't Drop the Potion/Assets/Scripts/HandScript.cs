using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject handPotion = null;
    public GameObject handIngredient = null;
    public GameObject potion = null;

    private bool isHolding;
    private bool failed = false;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(potion.transform.position, 2);
    }

   
    private void Start()
    {
    }

    private void Update()
    {
        if (potion != null)
        {
            if (potion.activeInHierarchy)
            {
                if (Physics.CheckSphere(potion.transform.transform.position, 2))
                {
                    if (!isHolding && Input.GetKey(KeyCode.G))
                    {
                        isHolding = true;
                        
                    }
                }
            }
            if (isHolding && Input.GetKey(KeyCode.G))
            {
                potion.SetActive(false);
                handPotion.SetActive(true);
            }
            if (isHolding && !Input.GetKey(KeyCode.G))
            {
                failed = true;

            };

        }
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