using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private GameObject cameraObj;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // move direction directly from axes
        float moveY = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;
        moveDirection.y = moveY;

        // input detected, rotate player to face camera direction
        if (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude != 0)
        {
            Quaternion rotation = transform.rotation;
            rotation.eulerAngles = cameraObj.transform.rotation.eulerAngles;
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
