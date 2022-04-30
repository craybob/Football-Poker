using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositionHandScript : MonoBehaviour
{
    public int _comand;
    public int _position;
    GameObject GameSceneScript;

    [SerializeField] bool flopHand;


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

        if (_position < 4 && !flopHand)
        {
            if (_comand == GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[NextPosition].GetComponent<CardPositionHandScript>()._comand && PlayerPrefs.GetInt("VEff_VKL") == 0)
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position].SetActive(true);
            }
            else
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position].SetActive(false);
            }
        }
        if (_position < 4 && flopHand)
        {
            if (_comand == GameSceneScript.GetComponent<GameSceneScript>().CardPositionFlop[NextPosition].GetComponent<CardPositionHandScript>()._comand 
                && PlayerPrefs.GetInt("VEff_VKL") == 0
                && GameSceneScript.GetComponent<GameSceneScript>().CardPositionFlop[NextPosition].GetComponentInChildren<PlayerScript>() != null)
            
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position + 3].SetActive(true);
            }
            else
            {
                GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[_position + 3].SetActive(false);
            }
        }

        if (GameSceneScript.GetComponent<GameSceneScript>()._CartDelet != 0)
        {
            GameSceneScript.GetComponent<GameSceneScript>().LinesCombination[GameSceneScript.GetComponent<GameSceneScript>()._CartDelet + 3].SetActive(false);
        }


    }
}
