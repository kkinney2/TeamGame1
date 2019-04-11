using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Manager_Scene;
    public GameObject gate;
    public Image[] ImageKeys;
    public GameObject[] Keys;
    public GameObject[] KeysOnGate;
    public Text KeyText;
    public Text GeneralText;

    bool gateOpening = false;
    public int keyCount;

    void Start()
    {
        keyCount = 0;
        UpdateKeys();
    }

    void Update()
    {
        if (keyCount == 3)
        {
            gateOpening = true;
        }
    }

    public void PickUpKey()
    {
        keyCount++;
        UpdateKeys();
    }

    void UpdateKeys()
    {
        KeyText.text = "Keys: " + keyCount;
        Debug.Log("keycount: " + keyCount);

        if (keyCount == 0)
        {
            foreach (Image i in ImageKeys)
            {
                i.gameObject.SetActive(false);
            }
            foreach (GameObject gateKey in KeysOnGate)
            {
                if (gateKey != null)
                    gateKey.SetActive(false);
            }
        }

        if (keyCount > 0)
        {
            ImageKeys [keyCount - 1].gameObject.SetActive(true);
            KeysOnGate[keyCount - 1].gameObject.SetActive(true);
        }
    }

    int GetKeyCount()
    {
        return keyCount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gateOpening)
        {
            gate.GetComponent<Animator>().enabled = true;
        }
    }
}
