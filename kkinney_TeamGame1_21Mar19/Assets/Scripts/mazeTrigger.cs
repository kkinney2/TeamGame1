using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeTrigger : MonoBehaviour {

    public GameObject key;
    public bool isTriggered = false;
    public GameObject stairs;


    void Update()
    {
        if (isTriggered)
            Activate();
    }

    void Activate()
    {
        stairs.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == key)
        {
            isTriggered = true;
            Activate();
        }
    }
}
