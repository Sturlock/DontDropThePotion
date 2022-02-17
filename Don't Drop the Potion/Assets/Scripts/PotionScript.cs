using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    
   public void PickUp(HandScript handScript, bool holding)
    {
        if (Physics.CheckSphere(transform.transform.position, 2))
        {
            if (!handScript.isHolding && Input.GetKey(KeyCode.G))
            {
                handScript.isHolding = true;
            }
        }

        if (!holding)
        {
            handScript.handPotion = gameObject;

            gameObject.transform.parent = handScript.gameObject.transform;
        }
    }

}
