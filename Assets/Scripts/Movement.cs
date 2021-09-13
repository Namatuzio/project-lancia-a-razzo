using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float turnSpeed = 1f;
    Rigidbody ribo;
    // Start is called before the first frame update
    void Start()
    {
        ribo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ribo.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A) == true)
        {
            ApplyRotation(turnSpeed);
        }
        else if(Input.GetKey(KeyCode.D) == true)
        {
            ApplyRotation(-turnSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        ribo.freezeRotation = true; // Freezing rotation for manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        ribo.freezeRotation = false; // Unfreezing so physics system can take place
    }
}