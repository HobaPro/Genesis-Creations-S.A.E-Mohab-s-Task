using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour
{
    // This method to Deposit funds to player bank account if player have enough cash.
    public void Deposit(GameObject player, float amount)
    {
        // Validate amount
        if (amount <= 0)
        {
            UIManager.instance.AlertMessage("Please inter the amount you want to deposit.", true);

            return;
        }

        // Ensure is player have en enough cash to deposit
        if (player.GetComponent<Cash>().Amount < amount)
        {
            UIManager.instance.AlertMessage("You have not enough funds to withdraw it.", true);

            return;
        }

        player.GetComponent<Cash>().Amount -= amount;
        player.GetComponent<Bank>().Amount += amount;

        // Handle UI
        UIManager.instance.AlertMessage("Succeeded, Money added to your account.");
        UIManager.instance.EmptyAmountInput();
    }

    // This method to withdraw funds from player bank account if player have enough funds in him bank account.
    public void Withdraw(GameObject player, float amount)
    {
        // Validate amount
        if (amount <= 0)
        {
            UIManager.instance.AlertMessage("Please inter the amount you want to withdraw.", true);

            return;
        }

        // Ensure is player have en enough funds in him bank account to withdraw
        if (player.GetComponent<Bank>().Amount < amount)
        {
            UIManager.instance.AlertMessage("You have not enough funds to withdraw it.", true);

            return;
        }

        player.GetComponent<Bank>().Amount -= amount;
        player.GetComponent<Cash>().Amount += amount;

        // Handle UI
        UIManager.instance.AlertMessage("Succeeded, Please take your money.");
        UIManager.instance.EmptyAmountInput();
    }
}
