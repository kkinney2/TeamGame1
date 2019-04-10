using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject Gate;
    public Image[] ImageKeys;
    public GameObject[] Keys;
    public GameObject[] KeysOnGate;
    public Text KeyText;

    bool gateOpening = false;
    int keyCount;

    void Start()
    {
        SetKeyCount(0);
    }

    void Update()
    {
        /*if (keyCount >= Keys.Length)
        {
            //Gate.GetComponent<GateController>().OpenGate();
            SetKeyCount(0);
        }*/
    }

    public void PickUpKey()
    {
        Debug.Log("PickUpKey() called");
        SetKeyCount(keyCount + 1);
    }

    void SetKeyCount(int newMod)
    {
        Debug.Log("newKeyCount: " + newMod);

        keyCount = newMod;
        UpdateKeys();
    }

    void UpdateKeys()
    {
        KeyText.text = "Keys: " + keyCount;
        Debug.Log("keycount: " + keyCount);

        if (keyCount == 0)
        {
            // UI Images for key placeholders
            foreach (Image i in ImageKeys)
            {
                i.gameObject.SetActive(false);
            }
            foreach (GameObject gateKey in KeysOnGate)
            {
                gateKey.gameObject.SetActive(false);
            }
        }

        if (keyCount > 0)
        {
            // Using keyCount-- actually subtracts 1 from keyCount instead of passing reference
            ImageKeys [keyCount - 1].gameObject.SetActive(true);
            KeysOnGate[keyCount - 1].gameObject.SetActive(true);
        }
    }

    int GetKeyCount()
    {
        return keyCount;
    }
}
