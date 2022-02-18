using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StationType
{
    type1,type2,type3
}

public class StationScript : MonoBehaviour
{
    public StationType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case StationType.type1:
                Chop();
                break;

            case StationType.type2:
                Boil();
                break;

            case StationType.type3:
                Burner();
                break;

            default:
                return;
        }

    }

    private void Burner()
    {
        throw new NotImplementedException();
    }

    private void Boil()
    {
        throw new NotImplementedException();
    }

    private void Chop()
    {
        throw new NotImplementedException();
    }
}
