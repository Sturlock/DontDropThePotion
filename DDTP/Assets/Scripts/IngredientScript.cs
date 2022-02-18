using UnityEngine;

public enum IngredientType
{
    Feather, EyeBall, Mushroom
}

public class IngredientScript : MonoBehaviour
{
    public Rigidbody body;
    public MeshRenderer renderer;
    public Material material;
    public IngredientType type;

    // Start is called before the first frame update
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        if (material != renderer.material)
        {
            material = renderer.material;
        }
        body = GetComponent<Rigidbody>();
    }

    public void PickUp(HandScript handScript)
    {
        handScript.FindIngredientType(type);
        transform.parent = handScript.hand2.transform;
        transform.position = handScript.hand2.transform.position;
        transform.rotation = handScript.hand2.transform.rotation;
        body.isKinematic = true;
        body.useGravity = false;
    }

    public void DropIt(HandScript handScript)
    {
        body.useGravity = true;
        body.isKinematic = false;
        transform.parent = null;
        handScript.handPotion = null;
    }

    public bool StationIt(HandScript handScript)
    {
        if (handScript.handIngredient != null)
        {
            return true;
        }
        else
            return true;
    }
}