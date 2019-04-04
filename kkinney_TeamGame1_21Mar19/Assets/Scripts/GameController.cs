using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Gate;
    public Image[] ImageKeys;
    public GameObject[] Keys;
    public Text KeyText;

    bool gateOpening = false;
    int keyCount = 0;
    

	// Use this for initialization
	void Start () {
        AddKeyCount(0);
	}

    // Update is called once per frame
    void Update()
    {
        if (keyCount >= Keys.Length)
        {
            //Gate.GetComponent<GateController>().OpenGate();
            AddKeyCount(-keyCount);
        }
    }

    public void PickUpKey()
    {
        AddKeyCount(1);
    }

    void AddKeyCount(int newMod)
    {
        keyCount += newMod;

        KeyText.text = "Keys: " + keyCount;

        if(keyCount == 0)
        {
            // UI Images for key placeholders
            foreach (Image i in ImageKeys)
            {
                i.gameObject.SetActive(false);
            }
        }

        if (keyCount > 0)
        {
            ImageKeys[keyCount--].gameObject.SetActive(true);
        }
    }

    int GetKeyCount()
    {
        return keyCount;
    }
}
