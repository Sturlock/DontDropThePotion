using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject GOText;
    void Start()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        GOText.SetActive(true);
    }
}
