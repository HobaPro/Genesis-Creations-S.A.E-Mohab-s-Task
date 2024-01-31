using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Item
{
    private void Awake()
    {
        id = GameManager.instance.GenerateItemId();
        name = "Tomato";
        price = 15.0f;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }
}
