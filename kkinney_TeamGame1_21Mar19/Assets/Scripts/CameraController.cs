using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float angleModX = 20;
    public float angleModY = 20;

    Vector3 offset;
    float xPos;
    float yPos;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;
        transform.RotateAround( player.transform.position,  Vector3.up, angleModX * Input.GetAxis("Mouse X"));

        if (transform.rotation.eulerAngles.x > -30 && transform.rotation.eulerAngles.x < 90)
        {
            transform.RotateAround(player.transform.position, transform.TransformVector(Vector3.left), angleModY * Input.GetAxis("Mouse Y"));
        }
        else if (transform.rotation.eulerAngles.x < -30 && Input.GetAxis("Mouse Y") < 0)
        {
            transform.RotateAround(player.transform.position, transform.TransformVector(Vector3.left), angleModY * Input.GetAxis("Mouse Y"));
        }
        else if (transform.rotation.eulerAngles.x > 90 && Input.GetAxis("Mouse Y") > 0)
        {
            transform.RotateAround(player.transform.position, transform.TransformVector(Vector3.left), angleModY * Input.GetAxis("Mouse Y"));
        }
    }

    void LateUpdate()
    {
        offset = transform.position - player.transform.position;
        //transform.LookAt(player.transform.position);
    }
}
