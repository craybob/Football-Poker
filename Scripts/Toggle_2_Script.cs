using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_2_Script : MonoBehaviour
{

    public int _country_par;//russia 11 urugvai 12 horvatia 14 danya 6
    GameObject GameSceneScript;


    void Start()
    {
        GameSceneScript = GameObject.Find("GameSceneScript");
    }
    public void OnValueChanged(bool isOn)
    {
        GameSceneScript.GetComponent<GameSceneScript>()._country_par = _country_par;
    }
}
