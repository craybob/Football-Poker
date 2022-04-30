using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardPositionHandScript : MonoBehaviour
{
    public int _comand;
    public int _position;
    GameObject GameSceneScript;
    


    void Start()
    {
        GameSceneScript = GameObject.Find("GameSceneScript");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            _comand = child.GetComponent<PlayerScript>()._comand;
        }
        int NextPosition = _position + 1;

        if (_position < 4)
        {
            if (_comand == GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[NextPosition].GetComponent<CardPositionHandScript>()._comand)
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position].SetActive(true);
            }
            else
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position].SetActive(false);
            }
        }


    }
}
