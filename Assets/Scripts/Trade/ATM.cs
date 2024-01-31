using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Deposit(Bank playerAccount, float amount)
    {
        playerAccount.Amount += amount;
    }

    public void Withdraw(Bank playerAccount, float amount)
    {
        if(playerAccount.Amount < amount)
        {
            UIManager.instance.ErrorMessage("You have not enough funds to withdraw it.");

            return;
        }

        playerAccount.Amount -= amount;
    }
}
