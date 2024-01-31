using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance { get; private set; }

    [SerializeField] private Text CashTxt;
    [SerializeField] private Text BankTxt;
    private void Awake()
    {
        // Intialize Singleton
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void SetCashTxt(float value)
    {
        CashTxt.text = $"{value}$";
    }

    public void SetBankTxt(float value)
    {
        BankTxt.text = $"{value}$";
    }
}
