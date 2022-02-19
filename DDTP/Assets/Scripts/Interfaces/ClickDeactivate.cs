using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDeactivate : MonoBehaviour
{
    public GameObject HowTo;

    public void onClick()
    {
        HowTo.SetActive(false);
    }
}
