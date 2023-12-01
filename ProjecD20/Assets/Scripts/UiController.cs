using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public TMP_InputField resultIn;
    public int resultOut;

    public void SetDiceResult()
    {
        if (Int32.TryParse(resultIn.text, out resultOut))
        {
            
            // resOut.text = resultIn.text;
        }
        else
        {
            Debug.Log("Error: can't convert dice result to int");
        }
    }
}
