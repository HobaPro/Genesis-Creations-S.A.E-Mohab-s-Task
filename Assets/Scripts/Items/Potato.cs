using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Potato : Item
{
    private void Awake()
    {
        id = GameManager.instance.GenerateItemId();
        name = "Potato";
        price = 10.0f;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }
}
