using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endLevel : MonoBehaviour {

    public Manager_Scene sceneManager;
    public Text GeneralText;

    public void EndOfLevel()
    {
        GeneralText.text = "End Of Level";
        sceneManager.MainMenu();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EndOfLevel();
        }
    }
}
