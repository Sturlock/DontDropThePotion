using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public List<IngredientType> entry;
    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public void PickUp(HandScript handScript)
    {
        transform.parent = handScript.hand1.transform;
        transform.position = handScript.hand1.transform.position;
        
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

    public void CheckIngredient(IngredientType type)
    {
        foreach(IngredientType ingredient in entry)
        {
            if(type == ingredient)
            {
                entry.Remove(ingredient);
            }
        }
    }

}
