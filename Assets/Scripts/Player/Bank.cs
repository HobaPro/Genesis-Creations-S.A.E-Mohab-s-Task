using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static event Action<float> OnBankChanged;

    private float _amount { get; set; }
    public float Amount
    {
        get => this._amount;
        set
        {
            _amount = value;
            OnBankChanged?.Invoke(_amount);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _amount = 1000.0f;
    }
}
