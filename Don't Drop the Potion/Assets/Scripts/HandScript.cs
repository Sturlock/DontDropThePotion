using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand1;
    public GameObject hand2;

    public GameObject handPotion = null;
    public GameObject handIngredients;
    private DetectionRayCast detection;
    public LayerMask layerHolding;

    private bool isHoldingPotion;
    private LayerMask potionLayer;
    private bool isHoldingIngredient;
    private LayerMask ingredientLayer;
    private bool failed = false;

    private void Start()
    {
        detection = GetComponent<DetectionRayCast>();
    }

    private void Update()
    {
        if (!failed)
        {
            if (!isHoldingPotion && Input.GetKey(KeyCode.G))
            {
                GameObject target;
                target = detection.inSightTarget;
                potionLayer = target.layer;
                target.layer = layerHolding;
                PotionScript potion = target.GetComponent<PotionScript>();
                handPotion = target;
                potion.PickUp(this);
                isHoldingPotion = true;
            }
            else if (isHoldingPotion && !Input.GetKey(KeyCode.G))
            {
                failed = true;
                isHoldingPotion = false;
            }

            if (isHoldingPotion)
            {
                if (!isHoldingIngredient && Input.GetKeyDown(KeyCode.E))
                {
                    GameObject target;
                    target = detection.inSightTarget;
                    ingredientLayer = target.layer;
                    target.layer = layerHolding;
                    IngredientScript ingredient = target.GetComponent<IngredientScript>();
                    handIngredients = target;
                    ingredient.PickUp(this);
                    isHoldingIngredient = true;
                }
                else if (isHoldingIngredient && Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingIngredient = false;
                    handIngredients.layer = ingredientLayer;
                    handIngredients.GetComponent<IngredientScript>().DropIt(this);
                }
            }
        }
        else
        {
            handPotion.GetComponent<PotionScript>().DropIt(this);
        }
    }

    public void FindIngredientType(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.type1:
                Debug.Log("Word1");
                break;

            case IngredientType.type2:
                Debug.Log("Word2");
                break;

            case IngredientType.type3:
                Debug.Log("Word3");
                break;

            default:
                return;
        }
    }
}