using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneScript : MonoBehaviour
{
    public GameObject _ball;

    string NP = "�����";
    string NA = "��";
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
