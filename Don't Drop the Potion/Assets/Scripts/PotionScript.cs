using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
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

}
