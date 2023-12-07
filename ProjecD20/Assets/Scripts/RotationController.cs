using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private GameObject blackHole;

    private bool isMoving = false;
    private bool startedRoll = false;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if dice was rolled yet and its position changed
        if (!startedRoll && (transform.position != startPosition))
        {
            isMoving = true;
            startedRoll = true;
        }

        // While dice is not in place continue rolling
        if (isMoving && (transform.position != blackHole.transform.position))
        {
            transform.Rotate(rotationSpeed, 0, 0);            
        } 

        // When dice is in place stop rolling and turn on the right side 
        else if (isMoving)
        {
            isMoving = false;
            ResultController.SetRandomResult();
            SetSide();
        }

    }

    // Turns dice on the right side
    public void SetSide()
    {
        switch (ResultController.diceResult)
        {
            case 1:
                transform.localRotation = Quaternion.Euler(-110.962f, 120f, -57.948f);
                break;

            case 2:
                transform.localRotation = Quaternion.Euler(-248.952f, 180f, -58.08801f);
                break;

            case 3:
                transform.localRotation = Quaternion.Euler(-35.263f, -157.724f, -13.291f);
                break;
                
            case 4:
                transform.localRotation = Quaternion.Euler(159.068f, -120f, 31.595f);
                break;
            
            case 5:
                transform.localRotation = Quaternion.Euler(0, 150f, 138.1897f);
                break;
            
            case 6:
                transform.localRotation = Quaternion.Euler(0, -30f, 280.9f);
                break;
            
            case 7:
                transform.localRotation = Quaternion.Euler(-35.245f, 157.84f, -283.417f);
                break;
            
            case 8:
                transform.localRotation = Quaternion.Euler(35.256f, -22.341f, -13.328f);
                break;
            
            case 9:
                transform.localRotation = Quaternion.Euler(215.267f, -22.237f, 76.814f);
                break;
            
            case 10:
                transform.localRotation = Quaternion.Euler(20.962f, -60f, 31.862f);
                break;
            
            case 11:
                transform.localRotation = Quaternion.Euler(200.928f, 60f, 31.77299f);
                break;
            
            case 12:
                transform.localRotation = Quaternion.Euler(35.21f, 22.212f, 76.782f);
                break;
            
            case 13:
                transform.localRotation = Quaternion.Euler(215.256f, 22.23f, -13.328f);
                break;
            
            case 14:
                transform.localRotation = Quaternion.Euler(144.885f, 202.18f, -283.235f);
                break;
            
            case 15:
                transform.localRotation = Quaternion.Euler(0, -150f, 100.9f);
                break;
            
            case 16:
                transform.localRotation = Quaternion.Euler(0, 30f, 323.059f);
                break;
            
            case 17:
                transform.localRotation = Quaternion.Euler(-20.595f, 120f, 31.823f);
                break;
            
            case 18:
                transform.localRotation = Quaternion.Euler(144.935f, 157.724f, -13.28799f);
                break;
            
            case 19:
                transform.localRotation = Quaternion.Euler(-69.112f, 180f, -58.364f);
                break;
            
            case 20:
                transform.localRotation = Quaternion.Euler(69.014f, 120f, -58.045f);
                break;
            
            default:
                Debug.Log("Wrong diceResult in RotationController script");
                return;
        }

        // Call event
        EventManager.SendDiceResult();
    }
}
