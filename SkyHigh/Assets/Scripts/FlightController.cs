// FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author: [FIRAT YALDIZ] | Student ID: [230446045]


using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; // degrees/second
    [SerializeField] private float yawSpeed = 45f;   // degrees/second
    [SerializeField] private float rollSpeed = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 5f; // units/second

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb ; //Physics component

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        // Then set rb.freezeRotation = true.
        // Why is freezeRotation needed? Answer in your PDF.
        rb = GetComponent<Rigidbody>(); //get rigidbody
        rb.freezeRotation =  true;  //Stop Unity physic rotating 

    }

    void Update()
    {
        // Call movement every frame

        HandleRotation();
        HandleThrust();

    }

    private void HandleRotation()
    {
        // TODO (Task 3-C):
        

        // Pitch
        float upDownInput = Input.GetAxis("Vertical");
        transform.Rotate( Vector3.right * upDownInput*pitchSpeed * Time.deltaTime);
       
        // left right rotation (yaw)
        float leftRightInput = Input.GetAxis("Horizontal");

        transform.Rotate( Vector3.up * leftRightInput *yawSpeed * Time.deltaTime) ;
        // Roll (q e)
        float rollValue = 0f ;
        if (Input.GetKey(KeyCode.Q))
        {
            rollValue = 1f; // turn left
        }
       
        else if (Input.GetKey(KeyCode.E))
        {
            rollValue = -1f; //turn right

        }
        //Rotate around Z axis based on Q or E key
        transform.Rotate(Vector3.forward* rollValue * rollSpeed *Time.deltaTime);


    }

    private void HandleThrust()
    {
        
        // TODO (Task 3-D) :
        // Presss space to go forward
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}