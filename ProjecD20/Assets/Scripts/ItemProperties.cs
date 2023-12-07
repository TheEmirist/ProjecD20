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

    void SetBonusField()
    {
        itemBonusField.text = itemBonus.ToString();
    }
}
