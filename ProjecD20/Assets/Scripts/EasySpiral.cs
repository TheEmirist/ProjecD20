using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class EasySpiral : MonoBehaviour
{
    [SerializeField] private GameObject blackhole;
    [SerializeField] private float speed = 2f;
    [Header("Rotation degree")]
    [SerializeField] private int x;
    [SerializeField] private int y = 60;
    [SerializeField] private int z;
    private Vector3 direction;
    private float distanceThisFrame;
    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Calculate the direction vector from our object straight to the central point
            direction = blackhole.transform.position - transform.position;
            // Rotate the direction by an angle
            // Quaternions are used in unity to represent rotations. 
            // Euler method returns rotation around x, y and z axis.
            // Then we multiply it with our direction vector to rotate it.
            direction = Quaternion.Euler(x, y, z) * direction;
            // We also have to calculate how much we want to move the object
            distanceThisFrame = speed * Time.deltaTime;
            // The last part is to apply the movement to the object
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        }
        // To prevent constant moving and shaking check the distance
        if (direction.magnitude <= 0.05f)
        {
            transform.position = blackhole.transform.position;
            isMoving = false;
        }
    }
}
