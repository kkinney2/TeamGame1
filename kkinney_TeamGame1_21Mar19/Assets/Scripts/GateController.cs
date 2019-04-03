using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

    public Vector3 EndTransPos;

    bool openGate = false;

	
	// Update is called once per frame
	void Update () {
        if (openGate == true)
        {
            Debug.Log("Gate Moving");
            if (transform.position.y >= EndTransPos.y)
            {
                Debug.Log("Moving up");
                transform.Translate(Vector3.up * 2f * Time.deltaTime);
            }
        }
	}

    public void OpenGate()
    {
        Debug.Log("Gate Toggled");
        openGate = !openGate;
    }
}
