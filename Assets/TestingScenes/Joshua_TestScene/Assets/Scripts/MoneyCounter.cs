using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private int moneyAmount = 0;
    [SerializeField] private TMPro.TMP_Text MoneyCountText;
    public UnityEvent onMoneySpentAndTrue;
    public void AddMoney(int add)
    {
        moneyAmount += add;
        MoneyCountText.text = moneyAmount.ToString();
        
    }

    public void SetMoney(int set)
    {
        moneyAmount = set;
        MoneyCountText.text = moneyAmount.ToString();
    }

    
    public void CompareMoney(int shopItemCost)
    {
        if (shopItemCost <= moneyAmount)
        {
            onMoneySpentAndTrue.Invoke();
            moneyAmount -= shopItemCost;
        }
        else if (shopItemCost > moneyAmount)
        {
            Debug.Log($"Not enough money. Missing {shopItemCost-moneyAmount}.");
        }
    }
}
