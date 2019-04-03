using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundParent : MonoBehaviour {

    public float zDirMod;
    public float rotSpeed;
	
	// Update is called once per frame
	void Update () {

        Vector3 targetDir = transform.parent.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(transform.parent.transform.position, new Vector3(1, 1 + 1 * Random.Range(0,1) , 1 * zDirMod), rotSpeed * Time.deltaTime);
	}
}
