using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int _number;
    public Text _number_txt;
    public int _comand;
    public Text _comand_txt;
    GameObject GameSceneScript;
    public int _country;
    public int _liga;
    public int _arbitr = 0;

    public int _combination_1 = 0;
    public int _combination_2 = 0;
    public int _combination_3 = 0;

    public bool Top50;
    public int WorldRayting;

    public bool _is_Player = false;
    public bool _is_Enemy_Flop = false;
    public bool _is_Enemy_Hand = false;

    public string _NamePlayer;
    public string _NameTeam;

    void Start()
    {
        GameSceneScript = GameObject.Find("GameSceneScript"); _number_txt.text = _number.ToString(); _comand_txt.text = _comand.ToString();

        _number_txt.transform.parent.GetComponent<Image>().enabled = false;
        _number_txt.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(113f, 32f);
        _number_txt.transform.parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 226f);
        _number_txt.color = Color.white;
        _number_txt.fontSize = 30;

        _comand_txt.transform.parent.GetComponent<Image>().enabled = false;
        _comand_txt.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(113f, -252f);
        _comand_txt.transform.parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 226f);
        _comand_txt.color = Color.white;
        _comand_txt.fontSize = 27;

        _number_txt.gameObject.AddComponent<Outline>();
        _comand_txt.gameObject.AddComponent<Outline>();

        string[] MassText = gameObject.GetComponent<Image>().sprite.name.Split(' ');

        if (MassText.Length == 1)
        {
            _NamePlayer = MassText[0];
        }

        if (MassText.Length == 2)
        {
            _NamePlayer = MassText[1];
        }
        if (MassText.Length == 3)
        {
            _NamePlayer = MassText[1] + " " + MassText[2];
        }
        _number_txt.text = _NamePlayer;

        _comand_txt.text = _NameTeam;



        if (PlayerPrefs.GetInt("EndGame") == 0)
        {
            _number_txt.enabled = false;
        }
        else
        {
            _number_txt.enabled = true;
        }


    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("NT_VKL") == 0)
        {
            _comand_txt.enabled = true;
        }
        if (PlayerPrefs.GetInt("NT_VKL") == 1)
        {
            _comand_txt.enabled = false;
        }

        if (PlayerPrefs.GetInt("NP_VKL") == 0)
        {
            _number_txt.enabled = true;
        }
        if (PlayerPrefs.GetInt("NP_VKL") == 1)
        {
            _number_txt.enabled = false;
        }


        if (GetComponent<PlayerScript>()._is_Enemy_Hand == true || GetComponent<PlayerScript>()._is_Enemy_Flop == true)
        {
            _comand_txt.transform.parent.GetComponent<RectTransform>().localScale = new Vector3(0.7f,0.7f,0.7f);
            _comand_txt.transform.parent.GetComponent<RectTransform>().localPosition = new Vector3(0,-50,0);
            _number_txt.transform.parent.GetComponent<RectTransform>().localScale = new Vector3(0.7f,0.7f,0.7f);
            _number_txt.transform.parent.GetComponent<RectTransform>().localPosition = new Vector3(0,-70,0);
        }
        

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Hand_btn")
        {
            //print("OnTriggerStay2D " + collision.name);
            // GameSceneScript.GetComponent<GameSceneScript>().GoHand();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // print("OnTriggerStay2D " + collision.name);
    }
}
