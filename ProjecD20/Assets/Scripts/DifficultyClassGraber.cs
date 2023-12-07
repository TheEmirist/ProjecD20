using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyClassGraber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Updates text. Used function for further usage
    void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = ResultController.difficultyClass.ToString();
    }
}
