using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand1;
    public GameObject hand2;

    public GameObject handPotion = null;
    public GameObject handIngredient;
    public IngredientSpawner spawner;
    private DetectionRayCast detection;
    public LayerMask layerHolding;
    [SerializeField]
    private bool isHoldingPotion;
    private LayerMask potionLayer;
    [SerializeField]
    private bool isHoldingIngredient;
    private LayerMask ingredientLayer;
    private IngredientType? ingredientType;
    private bool failed = false;
    private bool done = false;

    private void Start()
    {
        detection = GetComponent<DetectionRayCast>();
        spawner = FindObjectOfType<IngredientSpawner>();
    }

    private void Update()
    {
        if (!failed)
        {
            if (!isHoldingPotion && Input.GetKey(KeyCode.G))
            {
                GameObject target;
                if (detection.inSightTarget != null)
                {
                    target = detection.inSightTarget;
                    if (target.CompareTag("Potion"))
                    {
                        potionLayer = target.layer;
                        target.layer = layerHolding;
                        GameManager gm = FindObjectOfType<GameManager>();
                        PotionScript potion = target.GetComponent<PotionScript>();
                        handPotion = target;
                        gm.FindEntry();
                        potion.PickUp(this);
                        isHoldingPotion = true;
                    }
                }
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

                    if (detection.inSightTarget != null)
                    {
                        target = detection.inSightTarget;
                        if (target.CompareTag("Ingredient"))
                        {
                            ingredientLayer = target.layer;
                            target.layer = layerHolding;
                            IngredientScript ingredient = target.GetComponent<IngredientScript>();
                            handIngredient = target;
                            ingredient.PickUp(this);
                            spawner.NewIngredient(this);
                            isHoldingIngredient = true;
                        }
                    }
                }
                else if (isHoldingIngredient && Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingIngredient = false;
                    handIngredient.layer = ingredientLayer;
                    handIngredient.GetComponent<IngredientScript>().DropIt(this);
                }

                if (detection.inSightTarget != null)
                {
                    if (detection.inSightTarget.GetComponent<StationScript>())
                    {
                        bool hasIngred;

                        if (!done && Input.GetKey(KeyCode.F))
                        {
                            StationScript station = detection.inSightTarget.GetComponent<StationScript>();
                            if (handIngredient != null)
                            {
                                IngredientScript ingredient = handIngredient.GetComponent<IngredientScript>();
                                switch (ingredientType)
                                {
                                    case IngredientType.Mushroom:
                                        if (station.type == StationType.chop)
                                        {
                                            isHoldingIngredient = false;
                                            hasIngred = ingredient.StationIt(this);
                                            done = station.Chop(this, hasIngred);
                                        }
                                        break;

                                    case IngredientType.EyeBall:
                                        if (station.type == StationType.boil)
                                        {
                                            isHoldingIngredient = false;
                                            hasIngred = ingredient.StationIt(this);
                                            done = station.Boil(this, hasIngred);
                                        }
                                        break;

                                    case IngredientType.Feather:
                                        if (station.type == StationType.burner)
                                        {
                                            isHoldingIngredient = false;
                                            hasIngred = ingredient.StationIt(this);
                                            done = station.Burner(this, hasIngred);
                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        if (done)
                        {
                            PotionScript potion = handPotion.GetComponent<PotionScript>();
                            potion.CheckIngredient(handIngredient.GetComponent<IngredientScript>().type);
                            potion.PotionFinished();
                            handIngredient.SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            if (handPotion != null)
                handPotion.GetComponent<PotionScript>().DropIt(this);
        }
        if (handIngredient != null)
        {
            if (!handIngredient.activeSelf && done)
            {
                Destroy(handIngredient);
                handIngredient = null;
                done = false;
            }
        }

        if (detection.inSightTarget != null)
        {
            if (detection.inSightTarget.CompareTag("End") && isHoldingPotion)
            {
                PotionScript potion = handPotion.GetComponent<PotionScript>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingPotion = false;
                    isHoldingIngredient = false;
                    if (potion.tempEntry.Count == 0 && potion.start)
                    {
                        GameManager gm = FindObjectOfType<GameManager>();
                        gm.CompletedPotion();
                        Destroy(handPotion);
                        handPotion = null;
                    }
                }
            }
        }
    }

    public void FindIngredientType(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Mushroom:
                Debug.Log("Mushroom");
                ingredientType = type;
                break;

            case IngredientType.EyeBall:
                Debug.Log("EyeBall");
                ingredientType = type;
                break;

            case IngredientType.Feather:
                Debug.Log("Feather");
                ingredientType = type;
                break;

            default:
                ingredientType = null;
                return;
        }
    }
}