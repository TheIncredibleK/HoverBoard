using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverboardController : MonoBehaviour {

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;

    // Completely private variables
    private float horizontal;
    private float vertical;

    private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        SetDirections();
        myRigidBody.AddForce((Vector3.right * horizontal * acceleration * Time.deltaTime) + 
        (Vector3.forward * vertical * acceleration) * Time.fixedDeltaTime, ForceMode.Acceleration);
        myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, maxSpeed);
	
    }


    private void SetDirections()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal= " + horizontal);
        vertical = Input.GetAxis("Vertical");
        Debug.Log("Vertical= " + vertical);
    }
}
