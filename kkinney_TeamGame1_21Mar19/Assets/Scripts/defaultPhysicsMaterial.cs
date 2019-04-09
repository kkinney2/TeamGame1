using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultPhysicsMaterial : MonoBehaviour {

    public PhysicMaterial physicMaterial;

	void Start () {
        Transform[] allObjects = FindObjectsOfType<Transform>();
        foreach (Transform t in allObjects)
        {
            if (t.GetComponent<MeshCollider>() != null)
            {
                t.GetComponent<MeshCollider>().material = physicMaterial;
            }
        }
	}
}
