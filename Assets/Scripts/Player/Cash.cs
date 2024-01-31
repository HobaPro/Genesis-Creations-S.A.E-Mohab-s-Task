using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public static event Action<float> OnCashChanged;

    private float _amount { get; set; }
    public float Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnCashChanged?.Invoke(_amount);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _amount = 3000.0f;
    }
}
