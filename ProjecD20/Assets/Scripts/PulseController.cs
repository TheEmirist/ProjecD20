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
    private float m_scrollAmount;

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
        
    }

    void OnMouseOver()
    {
        PulseTheDice();
    }

    void PulseTheDice()
    {
        m_scrollAmount += Time.deltaTime * expandSpeed;
        float percent = expandCurve.Evaluate(m_scrollAmount);
        transform.localScale = Vector3.Lerp(startSize, targetSize, percent);
    }
}
