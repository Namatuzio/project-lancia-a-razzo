using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] AudioClip engine;
    Rigidbody ribo;
    AudioSource auso;
    // Start is called before the first frame update
    void Start()
    {
        ribo = GetComponent<Rigidbody>();
        auso = GetComponent<AudioSource>();
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
            if(!auso.isPlaying)
            {
                auso.PlayOneShot(engine);
            }
            ribo.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
        else
        {
            auso.Stop();
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
