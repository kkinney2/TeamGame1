using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] keys;
    public Text keyText;

    bool gateOpen = false;
    int keyCount = 0;
    

	// Use this for initialization
	void Start () {
        AddKeyCount(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (keyCount >= keys.Length)
        {
            gateOpen = true;
        }
	}

    void AddKeyCount(int newMod)
    {
        keyCount += newMod;

        keyText.text = "Keys: " + keyCount;
    }

    int GetKeyCount()
    {
        return keyCount;
    }
}
