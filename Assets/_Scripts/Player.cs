using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnEnable()
    {
        Simulator.OnNewPlayer += Pla;
    }

    private void Pla(string arg1, string arg2, DateTime arg3)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
