using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_1_Script : MonoBehaviour
{
    public int _liga_par;
    GameObject GameSceneScript;
    GameObject GM;
    

    void Start()
    {
        GameSceneScript = GameObject.Find("GameSceneScript");
        GM = GameObject.Find("GameManager");
    }
    public void OnValueChanged(bool isOn)
    {
        GM.GetComponent<GameManager>().Splay(1);
        GameSceneScript.GetComponent<GameSceneScript>()._liga_par = _liga_par;
        
    }
}
