using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public bool start = false;
    public List<IngredientType> entry = new List<IngredientType>();
    public List<IngredientType> tempEntry = new List<IngredientType>();
    public Mesh meshFinishedProduct;
    public Material matFinishedProduct;
    Rigidbody body;

    public GameObject explosion;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public void PickUp(HandScript handScript)
    {
        transform.parent = handScript.hand1.transform;
        transform.position = handScript.hand1.transform.position;
        tempEntry = new List<IngredientType>(entry);
        body.isKinematic = true;
        body.useGravity = false;
    }

    public void DropIt(HandScript handScript)
    {
        body.useGravity = true;
        body.isKinematic = false;
        transform.parent = null;
        handScript.handPotion = null;

        explosion.SetActive(true);

    }

    public void CheckIngredient(IngredientType type)
    {
        foreach(IngredientType ingredient in tempEntry)
        {
            if(type == ingredient)
            {
                tempEntry.Remove(ingredient);
                break;
            }
        }
    }
    
    public void PotionFinished()
    {
        if(tempEntry.Count == 0)
        {
                gameObject.GetComponent<MeshFilter>().mesh = meshFinishedProduct;
                gameObject.GetComponent<Renderer>().material = matFinishedProduct;
        }
    }
}
