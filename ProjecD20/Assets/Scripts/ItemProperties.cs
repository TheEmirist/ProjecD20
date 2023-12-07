using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    public string itemName = "Item name";
    public int itemBonus = 0;
    [SerializeField] TextMeshProUGUI itemNameField;
    [SerializeField] TextMeshProUGUI itemBonusField;

    void Start()
    {
        SetNameField();
        SetBonusField();
    }

    void SetNameField()
    {
        itemNameField.text = itemName;
    }

    // Sets values to text fields with a sign
    void SetBonusField()
    {
        if (itemBonus >= 0)
        {
            itemBonusField.text = "+" + itemBonus.ToString();
        }
        else
        {
            itemBonusField.text = itemBonus.ToString();
        }
    }
}
