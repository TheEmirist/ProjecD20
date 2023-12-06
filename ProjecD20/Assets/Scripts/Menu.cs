using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject dice;
    [SerializeField] GameObject successText;
    [SerializeField] GameObject failureText;
    [SerializeField] GameObject resultText;
    [SerializeField] GameObject difficultyClassField;
    int dc = 15;

    // Restarts the scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Checks if the roll was successful
    public void CheckSuccess()
    {
        int result = dice.GetComponent<RotationController>().GetResult();

        // Check for DC, critical success and critical failure
        if (result == 20 || (result >= dc && result != 1))
        {
            ReturnSuccess();
        } else
        {
            ReturnFailure();
        }
    }

    void ReturnSuccess()
    {
        successText.SetActive(true);
    }

    void ReturnFailure()
    {
        failureText.SetActive(true);
    }

    public void SetDC(int difficulty)
    {
        bool success = int.TryParse(difficultyClassField.GetComponent<TextMeshProUGUI>().text, out dc);
        if (!success)
        {
            Debug.Log("Can't convert DC to int Menu/CheckSuccess()");
        }
        difficultyClassField.GetComponent<TextMeshProUGUI>().text = difficulty.ToString();
    }

    // Converts result to string and 
    public void ShowResult()
    {
        int result = dice.GetComponent<RotationController>().GetResult();

        resultText.GetComponent<TextMeshProUGUI>().text = result.ToString();
        resultText.SetActive(true);
    }
}
