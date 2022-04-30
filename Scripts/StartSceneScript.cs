using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneScript : MonoBehaviour
{
    public GameObject _ball;

    string NP = "Игрок";
    string NA = "ИИ";
    void Start()
    {

        if (PlayerPrefs.GetString("NP") == "")
        {
            PlayerPrefs.SetString("NP", NP);
        }

        if (PlayerPrefs.GetString("NA") == "")
        {
            PlayerPrefs.SetString("NA", NA);
        }

    }

}
