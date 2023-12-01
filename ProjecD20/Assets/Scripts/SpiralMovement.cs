using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    [SerializeField] private GameObject blackHole;
    [SerializeField] private float speed = 9f;
    [Header("Rotation degree")]
    [SerializeField] private int xRotation;
    [SerializeField] private int yRotation = 80;
    [SerializeField] private int zRotation;
    private Vector3 direction;
    private float distanceThisFrame;
    private bool spiralMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spiralMovement)
        {
            // Calculate the direction vector from our object straight to the central point
            direction = blackHole.transform.position - transform.position;
            // Rotate the direction by an angle
            // Quaternions are used in unity to represent rotations. 
            // Euler method returns rotation around x, y and z axis.
            // Then we multiply it with our direction vector to rotate it.
            direction = Quaternion.Euler(xRotation, yRotation, zRotation) * direction;
            // We also have to calculate how much we want to move the object
            distanceThisFrame = speed * Time.deltaTime;
            // The last part is to apply the movement to the object
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
            // Rotate object toward movement direction
            transform.forward = direction;
        }
        // To prevent constant moving and shaking check the distance
        if (direction.magnitude <= 0.3f)
        {
            spiralMovement = false;
            transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
