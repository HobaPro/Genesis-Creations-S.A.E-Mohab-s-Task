using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id { get; private set; }
    public string Name;
    public float Price;

    private void Awake()
    {
        id = GameManager.instance.GenerateItemId();
    }
}
