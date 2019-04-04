using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameController GameController;
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float sprintSpeed = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private GameObject cameraObj;
    private float speed;
    float horizontalMove;
    float verticalMove;
    float timeIdle = 0;
    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if(horizontalMove < 1 && verticalMove < 1){
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButton("Sprint") && controller.isGrounded)
        {
            speed = sprintSpeed;
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }
        else if (speed == sprintSpeed && !controller.isGrounded)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = moveSpeed;
            
        }

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // move direction directly from axes
        float moveY = moveDirection.y;
        moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;
        moveDirection.y = moveY;

        // input detected, rotate player to face camera direction
        if (new Vector3(horizontalMove, 0, verticalMove).magnitude != 0)
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

        timeIdle += Time.deltaTime;

        animator.SetFloat("TimeIdle", timeIdle);

        if(timeIdle > 8)
        {
            timeIdle = 0;
            animator.SetFloat("TimeIdle", timeIdle);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Key")
        {
            other.gameObject.transform.position = Vector3.zero;
            GameController.PickUpKey();
        }

        if (other.name == "PressurePlate_Cube")
        {
            animator.SetBool("isPushing", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PressurePlate_Cube")
        {
            animator.SetBool("isPushing", false);
        }
    }
}
