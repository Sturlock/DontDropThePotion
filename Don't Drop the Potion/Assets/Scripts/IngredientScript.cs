using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType
{
    type1, type2, type3, type4
}



public class IngredientScript : MonoBehaviour, IInteract
{
    public MeshRenderer renderer;
    public Material material;
    public IngredientType type;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        if(material != renderer.material)
        {
            renderer.material = material;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Action()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        HandScript handScript = target.GetComponent<HandScript>();
        if(handScript != null)
        {
            handScript.FindIngredientType(this, type);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            if (target.GetComponent<PlayerScript>().interact)
            {
                Interact();
            }
        }
    }
}
