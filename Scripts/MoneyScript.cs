using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public int _all_money_user = 990; public Text _all_money_user_txt; public int _all_money_AI = 990; public Text _all_money_AI_txt;

    public int _stavka = 0; public Text _stavka_txt;
    public List<GameObject> Enemy_Cards = new List<GameObject>();
    public List<GameObject> Temp_Cards = new List<GameObject>(); //чтобы можно было удалять


    public bool _end_1_torgi; public bool _end_2_torgi;
    public bool _move_user;
    bool _PassUser;

    public int _stavka_user;
    public int _stavka_AI;
    public Text _info_txt;
    public GameObject Torgovla_END;
    public Text TorgovlaNumbers;
    public Color TorgovlaEndClr;
    public GameObject checkBtn;
    public GameObject PassPanel;
    GameObject GameSceneScript;
    GameObject _GMscr;
    public int Combination_1_torgi;
    public bool Test;
    int Plus_Stavka_AI; //на сколько комп подгнимает ставку

    public Animator Headpiece;
    int t;
    string _NP;
    string _NA;
    public bool TurnPlaer;

    public int enemyPassCounter;
    public VisualEffects _VEscr;


    TorgovlyaAnimation[] torgAnim;

    
    public void Check_User_btn()
    {
        
        
        if (_move_user && _PassUser == false)
        {
            if (_stavka_user > _stavka_AI)
            {
                _GMscr.GetComponent<GameManager>().Splay(17);
                if (PlayerPrefs.GetInt("Turn") == 0)
                {
                    _stavka = _stavka_user;
                    _info_txt.text = _NP + " подняли ставку до " + _stavka;
                    _move_user = false;
                    if (!_end_1_torgi)
                    {
                        Invoke("Move_AI_1round", 2f);
                    }
                    else
                    {
                        Invoke("Move_AI_2round", 2f);
                    }
                }
                else
                {
                    if (!_end_1_torgi)
                    {
                        TurnPlaer = false;
                        StartAI();
                    }
                    else
                    {
                        TurnPlaer = false;
                        StartAI2();
                    }
                    
                }
                
            }
            else if (!_end_1_torgi && TurnPlaer != true)
            {
                int Raznica = _stavka - _stavka_user;
                _stavka_user = _stavka;
                _all_money_user -= Raznica;
                _info_txt.text = _NP + " сделали чек, можете выбрать флоп";
                Torgovla_END.SetActive(true);
                _GMscr.GetComponent<GameManager>().Splay(18);
                TorgovlaNumbers.color = TorgovlaEndClr;
                checkBtn.GetComponent<Button>().enabled = false;

                for (int i = 0; i < torgAnim.Length; i++)
                {
                    torgAnim[i].GetComponent<TorgovlyaAnimation>().animPlay = false;
                }
                _end_1_torgi = true;
                GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[5];
                _VEscr.GetComponent<VisualEffects>().end();

            }
            else if ((_move_user) && (_end_1_torgi))
            {
                if (_stavka_user < _stavka_AI)
                {
                    print("чек во второй раз");
                    int Raznica = _stavka - _stavka_user;
                    _stavka_user = _stavka;
                    _all_money_user -= Raznica;
                    _info_txt.text = _NP + " сделали чек, вскрываемся";
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                }
            }
        }
    }
    public void Stavka_UP_btn()
    {
        if (_move_user && _PassUser == false)
        {
            if (_stavka_user > _stavka_AI)
            {
                _stavka = _stavka_user;
                _info_txt.text = _NP + " подняли ставку до " + _stavka;
                _move_user = false;
                if (!_end_1_torgi)
                {
                    Invoke("Move_AI_1round", 2f);
                }
                else
                {
                    Invoke("Move_AI_2round", 2f);
                }
            }
        }
    }
    void Move_AI_1round()
    {
        TurnPlaer = false;
        switch (Combination_1_torgi)
        {
            case 1: //Нет
                if (_stavka <= 20)
                {
                    Plus_Stavka_AI = Random.Range(1, 2) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 21 && _stavka <= 30)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 31)
                {
                    int Risk = Random.Range(0, 100);
                    if (Risk <= 50)
                    {
                        LooseAI();
                        return;
                    }
                    if (Risk >= 51)
                    {
                        Plus_Stavka_AI = Random.Range(1, 2) * 5;
                        StavkaEnemy();
                        return;
                    }

                    
                }
                break;

            case 2://Пара
                if (_stavka <= 50)
                {
                    Plus_Stavka_AI = 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 51 && _stavka <= 60)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 61)
                {
                    LooseAI();
                    return;
                }
                break;
            case 3://если только 3:
                if (_stavka <= 50)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 51 && _stavka <= 70)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 71)
                {
                    LooseAI();
                    return;
                }
                break;
            case 4://2 Пара
                if (_stavka <= 70)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 71 && _stavka <= 90)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 91)
                {
                    LooseAI();
                    return;
                }
                break;
            case 5://Фул хаус
                if (_stavka <= 90)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 91 && _stavka <= 110)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 111)
                {
                    LooseAI();
                    return;
                }
                break;
            case 6://у ИИ  каре
                if (_stavka <= 110)
                {
                    Plus_Stavka_AI = Random.Range(1, 7) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 111 && _stavka <= 150)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }

                if (_stavka >= 151)
                {
                    LooseAI();
                    return;
                }
                break;
            case 7://у ИИ Флеш
                if (_stavka <= 150)
                {
                    Plus_Stavka_AI = Random.Range(31, 60) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 151 && _stavka <= 210)
                {
                    Plus_Stavka_AI = Random.Range(31, 60) * 5;
                    StavkaEnemy();
                    return;
                }

                if (_stavka >= 211)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, можете выбрать флоп";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_1_torgi = true;
                    return;
                }
                break;
        }
   
    }


    void Move_AI_2round()
    {

        TurnPlaer = false;
        switch (Combination_1_torgi)
        {
            case 1: //Нет
                if (_stavka <= 20)
                {
                    Plus_Stavka_AI = Random.Range(1, 2) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 21 && _stavka <= 30)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    _GMscr.GetComponent<GameManager>().Splay(18);
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 31)
                {
                    int Risk = Random.Range(0, 100);
                    if (Risk <= 50)
                    {
                        LooseAI();
                        return;
                    }
                    if (Risk >= 51)
                    {
                        Plus_Stavka_AI = Random.Range(1, 2) * 5;
                        StavkaEnemy();
                        return;
                    }


                }
                break;

            case 2://Пара
                if (_stavka <= 50)
                {
                    Plus_Stavka_AI = 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 51 && _stavka <= 60)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 61)
                {
                    LooseAI();
                    return;
                }
                break;
            case 3://если только 3:
                if (_stavka <= 50)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 51 && _stavka <= 70)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 71)
                {
                    LooseAI();
                    return;
                }
                break;
            case 4://2 Пара
                if (_stavka <= 70)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 71 && _stavka <= 90)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 91)
                {
                    LooseAI();
                    return;
                }
                break;
            case 5://Фул хаус
                if (_stavka <= 90)
                {
                    Plus_Stavka_AI = Random.Range(1, 4) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 91 && _stavka <= 110)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 111)
                {
                    LooseAI();
                    return;
                }
                break;
            case 6://у ИИ  каре
                if (_stavka <= 110)
                {
                    Plus_Stavka_AI = Random.Range(1, 7) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 111 && _stavka <= 150)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }

                if (_stavka >= 151)
                {
                    LooseAI();
                    return;
                }
                break;
            case 7://у ИИ Флеш
                if (_stavka <= 150)
                {
                    Plus_Stavka_AI = Random.Range(31, 60) * 5;
                    StavkaEnemy();
                    return;
                }
                if (_stavka >= 151 && _stavka <= 210)
                {
                    Plus_Stavka_AI = Random.Range(31, 60) * 5;
                    StavkaEnemy();
                    return;
                }

                if (_stavka >= 211)
                {
                    int RaznicaAI = _stavka - _stavka_AI;
                    _stavka_AI = _stavka;
                    _all_money_AI -= RaznicaAI;
                    _info_txt.text = _NA + " делает чек, вскрываемся";
                    GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
                    _VEscr.GetComponent<VisualEffects>().end();
                    _GMscr.GetComponent<GameManager>().Splay(18);

                    Torgovla_END.SetActive(true);
                    _end_2_torgi = true;
                    GameSceneScript.GetComponent<GameSceneScript>().GoHand();
                    GameSceneScript.GetComponent<GameSceneScript>().Calculation();
                    return;
                }
                break;
        }


    }


    public void Money_UP_btn()
    {
        _stavka_user = _stavka;
        if (_move_user && _PassUser == false)
        {
            _GMscr.GetComponent<GameManager>().Splay(2);
            _stavka_user += 5;
            if (_stavka_user > _stavka_AI)
            {
                _stavka += 5;
            }

            _all_money_user -= 5;
            _stavka_user = _stavka;
        }
    }
    public void Money_DOWN_btn()
    {
        _stavka_user = _stavka;
        if ((_move_user) && (_stavka_user > _stavka_AI) && _PassUser == false)
        {
            _stavka_user -= 5;
            _stavka -= 5;
            _all_money_user += 5;
            _stavka_user = _stavka;
        }
        
    }
    public void Lose_btn()
    {
        if (_PassUser == false)
        {
            PassPanel.SetActive(true);
            _GMscr.GetComponent<GameManager>().Splay(5);
        }
        

    }
    public void PassNo() { PassPanel.SetActive(false); }

    public void PassYes() 
    { 
        PassPanel.SetActive(false);
        _all_money_AI += _stavka_AI;
        _info_txt.text = _NP + " спасовал";
        _PassUser = true;
        GameSceneScript.GetComponent<GameSceneScript>().animImage.sprite = GameSceneScript.GetComponent<GameSceneScript>()._HPWords[1];
        GameSceneScript.GetComponent<GameSceneScript>()._VSscr.end();
        GameSceneScript.GetComponent<GameSceneScript>().win = false;
        Invoke("PlayerPass", 3f);
    }
    void PlayerPass()
    {
        GameSceneScript.GetComponent<GameSceneScript>().EndOfRound();
    }

    void Start()
    {
        torgAnim = FindObjectsOfType<TorgovlyaAnimation>();


        _all_money_user = PlayerPrefs.GetInt("_all_money_user");
        _all_money_AI = PlayerPrefs.GetInt("_all_money_AI");

        GameSceneScript = GameObject.Find("GameSceneScript");
        _GMscr = GameObject.Find("GameManager");

        if (PlayerPrefs.GetInt("Hit_VKL") == 0)
        {
            _info_txt.enabled = true;
        }
        else
        {
            _info_txt.enabled = false;
        }

        if (PlayerPrefs.GetInt("VEff_VKL") == 0)
        {
            Headpiece.enabled = true;
            Headpiece.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            Headpiece.enabled = false;
            Headpiece.GetComponent<AudioSource>().mute = true;
        }



        _NA = PlayerPrefs.GetString("NA");
        _NP = PlayerPrefs.GetString("NP");


        if (PlayerPrefs.GetInt("Turn") == 1) 
        {
            Invoke("StartAI", 3f);
            PlayerPrefs.SetInt("Turn",0);
            TurnPlaer = false;

        }
        else
        {
            _move_user = true;
            TurnPlaer = true;
            PlayerPrefs.SetInt("Turn",1);
        }
        
        
        
        _stavka_user = 10;
        _stavka_AI = 0;
        Torgovla_END.SetActive(false);
        PassPanel.SetActive(false);

        for (int i = 0; i < torgAnim.Length; i++)
        {
            torgAnim[i].GetComponent<TorgovlyaAnimation>().animPlay = true;
        }
    }

    public void StartAI()              // первый ход компа
    {
        // выяснить комбинацию компа
        //print("количество = " + GameSceneScript.GetComponent<GameSceneScript>().Enemy_Cards.Count);


        int RiskBot;
        RiskBot = Random.Range(0, 100);
        if (RiskBot <= 1)
        {
            Plus_Stavka_AI = Random.Range(45, 55) * 5;
            StavkaEnemy();
            Combination_1_torgi = 7;
            return;
        }
        else
        {

            Enemy_Cards = GameSceneScript.GetComponent<GameSceneScript>().Enemy_Cards;
            int Count_Sovpad; //сколько одинаковых
            for (int i = 0; i < 5; i++) // для 5 и 4
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 5) //у ИИ Флеш
                {
                    Combination_1_torgi = 7;
                    Plus_Stavka_AI = Random.Range(34, 42) * 5;
                    StavkaEnemy();
                    Debug.Log("ИИ Флешь");
                    return;
                }
                else if (Count_Sovpad == 4) //у ИИ  каре
                {
                    Combination_1_torgi = 6;
                    Plus_Stavka_AI = Random.Range(24, 30) * 5;
                    StavkaEnemy();
                    Debug.Log("ИИ Каре");
                    return;
                }
            }

            if (Test == false)
            {
                for (int i = 0; i < 5; i++)
                {

                    Temp_Cards.Add(Enemy_Cards[i]);
                }
                Test = true;
            }






            for (int i = 0; i < 5; i++) // для 3+2
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Temp_Cards[i] = null;
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 3) //нашел 3
                {
                    // надо выяснить - есть ли 2
                    for (int j = 0; j < 5; j++)
                    {
                        if (Temp_Cards[j] != null)
                        {
                            foreach (var item in Temp_Cards)
                            {
                                if (item != null)
                                {
                                    if ((Temp_Cards[j].GetComponent<PlayerScript>()._comand ==
                                         item.GetComponent<PlayerScript>()._comand) &&
                                        (Temp_Cards[j].GetComponent<PlayerScript>()._number !=
                                         item.GetComponent<PlayerScript>()._number))
                                    {
                                        print("Фулхаус");
                                        Combination_1_torgi = 5;
                                        Plus_Stavka_AI = Random.Range(16, 22) * 5;
                                        StavkaEnemy();
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    //если только 3:
                    Combination_1_torgi = 3;
                    Plus_Stavka_AI = Random.Range(6, 14) * 5;
                    Debug.Log("ИИ Тройка");
                    StavkaEnemy();
                    return;
                }
            }

            for (int i = 0; i < 5; i++) //перезаполнение
            {
                Temp_Cards[i] = Enemy_Cards[i];
            }

            for (int i = 0; i < 5; i++) // для 2
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Temp_Cards[i] = null;
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 2) //нашел 2
                {
                    //надо выяснить - есть ли еще 2
                    for (int j = 0; j < 5; j++)
                    {
                        if (Temp_Cards[j] != null)
                        {
                            foreach (var item in Temp_Cards)
                            {
                                if (item != null)
                                {
                                    if ((Temp_Cards[j].GetComponent<PlayerScript>()._comand ==
                                         item.GetComponent<PlayerScript>()._comand) &&
                                        (Temp_Cards[j].GetComponent<PlayerScript>()._number !=
                                         item.GetComponent<PlayerScript>()._number))
                                    {
                                        print("2 пары");
                                        Combination_1_torgi = 4;
                                        Plus_Stavka_AI = Random.Range(8, 18) * 5;
                                        StavkaEnemy();
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    //Пара
                    Combination_1_torgi = 2;
                    Plus_Stavka_AI = Random.Range(4, 10) * 5;
                    Debug.Log("Пара");
                    StavkaEnemy();
                    return;
                }
            }

            //если пусто
            Combination_1_torgi = 1;
            Plus_Stavka_AI = Random.Range(1, 4) * 5;
            Debug.Log("Пусто");
            StavkaEnemy();
            return;
        }
    }

    

    public void StartAI2()              // Второй ход компа
    {
        // выяснить комбинацию компа
        //print("количество = " + GameSceneScript.GetComponent<GameSceneScript>().Enemy_Cards.Count);


        int RiskBot;
        RiskBot = Random.Range(0, 100);
        if (RiskBot <= 1)
        {
            Plus_Stavka_AI = Random.Range(45, 55) * 5;
            StavkaEnemy();
            Combination_1_torgi = 7;
            return;
        }
        else
        {

            Enemy_Cards = GameSceneScript.GetComponent<GameSceneScript>().Enemy_Cards;
            int Count_Sovpad; //сколько одинаковых
            for (int i = 0; i < 5; i++) // для 5 и 4
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 5) //у ИИ Флеш
                {
                    Combination_1_torgi = 7;
                    Plus_Stavka_AI = Random.Range(18, 22) * 5;
                    Debug.Log("ИИ Флешь");
                    StavkaEnemy();
                    return;
                }
                else if (Count_Sovpad == 4) //у ИИ  каре
                {
                    Combination_1_torgi = 6;
                    Plus_Stavka_AI = Random.Range(12, 16) * 5;
                    Debug.Log("ИИ Каре");
                    StavkaEnemy();
                    return;
                }
            }

            //for (int i = 0; i < 5; i++)
            //{

            //    Temp_Cards.Add(Enemy_Cards[i]);
            //}

            for (int i = 0; i < 5; i++) // для 3+2
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Temp_Cards[i] = null;
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 3) //нашел 3
                {
                    // надо выяснить - есть ли 2
                    for (int j = 0; j < 5; j++)
                    {
                        if (Temp_Cards[j] != null)
                        {
                            foreach (var item in Temp_Cards)
                            {
                                if (item != null)
                                {
                                    if ((Temp_Cards[j].GetComponent<PlayerScript>()._comand ==
                                         item.GetComponent<PlayerScript>()._comand) &&
                                        (Temp_Cards[j].GetComponent<PlayerScript>()._number !=
                                         item.GetComponent<PlayerScript>()._number))
                                    {
                                        print("Фулхаус");
                                        Combination_1_torgi = 5;
                                        Plus_Stavka_AI = Random.Range(10, 14) * 5;
                                        StavkaEnemy();
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    //если только 3:
                    Combination_1_torgi = 3;
                    Plus_Stavka_AI = Random.Range(4, 10) * 5;
                    Debug.Log("ИИ Тройка");
                    StavkaEnemy();
                    return;
                }
            }

            //for (int i = 0; i < 5; i++) //перезаполнение
            //{
            //    Temp_Cards[i] = Enemy_Cards[i];
            //}

            for (int i = 0; i < 5; i++) // для 2
            {
                Count_Sovpad = 1;
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand ==
                         item.GetComponent<PlayerScript>()._comand) &&
                        (Enemy_Cards[i].GetComponent<PlayerScript>()._number !=
                         item.GetComponent<PlayerScript>()._number))
                    {
                        Temp_Cards[i] = null;
                        Count_Sovpad++;
                    }
                }

                if (Count_Sovpad == 2) //нашел 2
                {
                    //надо выяснить - есть ли еще 2
                    for (int j = 0; j < 5; j++)
                    {
                        if (Temp_Cards[j] != null)
                        {
                            foreach (var item in Temp_Cards)
                            {
                                if (item != null)
                                {
                                    if ((Temp_Cards[j].GetComponent<PlayerScript>()._comand ==
                                         item.GetComponent<PlayerScript>()._comand) &&
                                        (Temp_Cards[j].GetComponent<PlayerScript>()._number !=
                                         item.GetComponent<PlayerScript>()._number))
                                    {
                                        print("2 пары");
                                        Combination_1_torgi = 4;
                                        Plus_Stavka_AI = Random.Range(6, 12) * 5;
                                        StavkaEnemy();
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    //Пара
                    Combination_1_torgi = 2;
                    Plus_Stavka_AI = Random.Range(4, 6) * 5;
                    Debug.Log("ИИ Пара");
                    StavkaEnemy();
                    return;
                }
            }

            //если пусто
            Combination_1_torgi = 1;
            Plus_Stavka_AI = Random.Range(1, 4) * 5;
            Debug.Log("Пусто");
            StavkaEnemy();
            return;
        }
    }

    void StavkaEnemy()
    {
        _GMscr.GetComponent<GameManager>().Splay(3);

        _stavka_AI += Plus_Stavka_AI;
        _all_money_AI -= Plus_Stavka_AI;
        _stavka += Plus_Stavka_AI;
        Headpiece.SetBool("Go", true);
        Headpiece.GetComponent<AudioSource>().Play();
        _info_txt.text = _NA + " поднял ставку до " + _stavka;
        _move_user = true;

    }

    public bool aiPass = false;
    public void LooseAI()
    {
        aiPass = true;
        int randomPass = Random.Range(0,1);

        if (PlayerPrefs.GetInt("EnemyPass") == 0)
        {
            PlayerPrefs.SetInt("EnemyPass", 1);
            _info_txt.text = _NA + " спасовал";
            _all_money_user += _stavka;

            GameSceneScript.GetComponent<GameSceneScript>().EndOfRound();
        }
        else if (PlayerPrefs.GetInt("EnemyPass") == 1)
        {

            if (!_end_1_torgi)
            {
                TurnPlaer = false;
                StartAI();
            }
            else
            {
                TurnPlaer = false;
                StartAI2();
            }
            PlayerPrefs.SetInt("EnemyPass", 0);
        }
    }

    void Update()
    {
        enemyPassCounter = PlayerPrefs.GetInt("EnemyPass");
        _all_money_user_txt.text = _all_money_user.ToString();
        _all_money_AI_txt.text = _all_money_AI.ToString();
        _stavka_txt.text = _stavka.ToString();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            LooseAI();
        }

        PlayerPrefs.SetInt("_all_money_user", _all_money_user);
        PlayerPrefs.SetInt("_all_money_AI", _all_money_AI);

        if (Headpiece.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            Headpiece.SetBool("Go", false);
        }

    }
}