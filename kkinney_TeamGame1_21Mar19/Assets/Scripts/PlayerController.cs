using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;

    float playerInputX;
    float playerInputY;
    Vector3 m_Velocity = Vector3.zero;
    float m_MovementSmoothing = .05f;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Movement(moveHorizontal * Time.deltaTime, moveVertical * Time.deltaTime);
	}

    void Movement(float moveX, float moveZ)
    {
        Vector3 targetVelocity = new Vector3(moveX, 0.0f, moveZ);
        //targetVelocity = moveTarget.transform.TransformVector(targetVelocity) * speed;

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        //rb.AddForce(targetVelocity * speed);
    }
}
