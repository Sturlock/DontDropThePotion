using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand1;
    public GameObject hand2;

    public GameObject handPotion = null;
    public GameObject[] handIngredients;
    private DetectionRayCast detection;

    [SerializeField] private bool isHolding;
    private bool failed = false;

    private void Start()
    {
        detection = GetComponent<DetectionRayCast>();
    }

    private void Update()
    {
        if (!failed)
        {
            if (!isHolding && Input.GetKey(KeyCode.G))
            {
                GameObject target;
                target = detection.inSightTarget;
                PotionScript potion = target.GetComponent<PotionScript>();
                handPotion = target;
                potion.PickUp(this);
                isHolding = true;
            }

            if (isHolding && !Input.GetKey(KeyCode.G))
            {
                failed = true;
                isHolding = false;
            }
        }
        else
        {
            handPotion.GetComponent<PotionScript>().DropIt(this);
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