using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{   
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForce !=0.0f)
        {
            body.angularVelocity = new Vector3(0.0f,sideForce, 0.0f);
        }
        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
    }
}
