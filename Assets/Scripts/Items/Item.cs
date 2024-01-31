using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int id {  get; protected set; }
    public string name { get; protected set; }
    public float price { get; protected set; }
}
