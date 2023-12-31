using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseController : MonoBehaviour
{
    [Header("Pulse variables")]
    [SerializeField] private AnimationCurve expandCurve;
    [SerializeField] private float expandAmount;
    [SerializeField] private float expandSpeed;

    private Vector3 startSize;
    private Vector3 targetSize;
    private float scrollAmount;
    private bool revertSize = false;

    void InitPulseEffectVariables()
    {
        startSize = transform.localScale;
        targetSize = startSize * expandAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitPulseEffectVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if (revertSize)
        {
            RevertSize();
        }
    }

    void OnMouseOver()
    {
        PulseTheDice();
    }

    // Allows dice pulse animation
    void PulseTheDice()
    {
        scrollAmount += Time.deltaTime * expandSpeed;
        float percent = expandCurve.Evaluate(scrollAmount);
        transform.localScale = Vector3.Lerp(startSize, targetSize, percent);
    }


    // Makes dice small again after pulsation ends
    void OnMouseExit()
    {
        revertSize = true;
    }

    void OnMouseEnter()
    {
        revertSize = false;
    }

    void RevertSize()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * expandSpeed);
    }
}
