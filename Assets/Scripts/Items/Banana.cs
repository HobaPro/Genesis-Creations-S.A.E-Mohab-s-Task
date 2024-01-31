using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Item
{
    private void Awake()
    {
        id = GameManager.instance.GenerateItemId();
        name = "Banana";
        price = 20.0f;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }
}
