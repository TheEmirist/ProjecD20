using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public static int diceResult;
    public static int difficultyClass = 15;
    private TextMeshProUGUI diceResultField;
    [SerializeField] GameObject successText;
    [SerializeField] GameObject failureText;
    [SerializeField] GameObject difficultyClassText;

    void Start()
    {
        diceResultField = GetComponent<TextMeshProUGUI>();
        diceResultField.text = null;

        EventManager.OnDiceRoll.AddListener(DiceRolled);
    }

    // Call when dice is rolled
    void DiceRolled()
    {
        ModifyDiceResultWithItems();
        diceResultField.text = diceResult.ToString();
        CheckSuccess();
    }

    // Sets random dice result between 1 and 20
    // I assume that in real game it would be commonly used so I made it static
    public static void SetRandomResult()
    {
        diceResult = Random.Range(1, 21);
    }

    // Sets difficulty class
    // I assume that in real game it would be commonly used so I made it static
    public static void SetDC(int dc)
    {
        difficultyClass = dc;
    }

    // Returns difficulty class
    // I assume that in real game it would be commonly used so I made it static
    public static int GetDC()
    {
        return difficultyClass;
    }

    void ModifyDiceResultWithItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject item in items)
        {
            diceResult += item.GetComponent<ItemProperties>().itemBonus;
        }
    }

    // Checks if the dice roll was successful
    void CheckSuccess()
    {
        // Check for DC, critical success and critical failure
        if (diceResult == 20 || (diceResult >= difficultyClass && diceResult != 1))
        {
            ReturnSuccess();
        } 
        else
        {
            ReturnFailure();
        }
    }

    // Used functions so that text appearing could be easily modified
    void ReturnSuccess()
    {
        successText.SetActive(true);
    }

    void ReturnFailure()
    {
        failureText.SetActive(true);
    }
}
