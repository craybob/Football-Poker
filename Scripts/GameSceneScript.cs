using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneScript : MonoBehaviour
{
    public List<GameObject> Test_Cards = new List<GameObject>();
    public GameObject HandPlayer; public GameObject FlopPlayer;
    public List<GameObject> _cards = new List<GameObject>();
    public List<GameObject> Hand_Cards = new List<GameObject>();
    public List<GameObject> _combination_1 = new List<GameObject>();
    public List<GameObject> _combination_2 = new List<GameObject>();

    public List<GameObject> Enemy_Cards = new List<GameObject>();
    public List<GameObject> _enemy_combination_1 = new List<GameObject>();
    public List<GameObject> _enemy_combination_2 = new List<GameObject>();
    public List<GameObject> _enemy_combination_3 = new List<GameObject>();
    public List<GameObject> _main_enemy_combination = new List<GameObject>();
    public List<GameObject> _second_enemy_combination = new List<GameObject>();

    public string PlayerString;
    public string AIString;
    public int _liga_AI_flop;

    public List<GameObject> Flop_cards = new List<GameObject>();
    public GameObject _flop_btn;
    public GameObject _hand_btn;
    int _hand_x = -332; int _hand_y = -70;
    public GameObject change_flop; public GameObject _liga; public GameObject _country;

    public bool _change_flop = false;
    public int _liga_par; public int _country_par;

    public List<GameObject> CardPositionHand = new List<GameObject>();
    public List<GameObject> CardPositionFlop = new List<GameObject>();
    public List<GameObject> CardEnemyPositionHand = new List<GameObject>();
    public List<GameObject> CardEnemyPositionFlop = new List<GameObject>();
    public List<GameObject> LinesCombination = new List<GameObject>();
    public GameObject EnemyHandPlayer;
    public GameObject EnemyFlopPlayer;
    public bool _flop_player_delete = false;
    public bool _flop_enemy_delet = false;
    public GameObject _recicler_player;
    public GameObject _recicler_polovina;
    GameObject MoneyScript; public GameObject Torgovla_END;
    public Text _info_txt;
    public int _score_user;
    public int _score_AI;
    int Number_temp = 400;
    public GameObject _sdacha_kart;
    public Sprite[] _HPWords; // 0 чек, 1 пас , 2 флоп , 3 победа , 4 поражение
    public Image animImage;
    public GameObject ballAnim;
    public GameObject rubashkaPrefab;

    public List<int> SortCartEnemy;
    public List<GameObject> CardEnemyPositionHandFinish = new List<GameObject>();
    public GameObject Finish;

    int[] EngClub = new int[5];
    int EngT1;int EngT2;
    
    public List<int> EnemyT;
    public List<int> PlayerT;

    string _NP;
    string _NA;
    private bool flopRaff;
    public List<GameObject> Sovpad;
    public List<GameObject> Sortfineshcart;
    GameManager GM;
    public int _CartDelet;


    //WIN PANEL
    [HideInInspector] public bool win;
    public GameObject nRPanel; // NextRoundPanel
    public Text winTxt;

    public GameObject _TorgObj;
    public GameObject _Eflop;
    public Animator _EFlopFinish;

    //Flop anim
    public GameObject flipAnim;
    public float cardSpawnTime;

    public bool flop;

    public VisualEffects _VSscr;

    public Image flagImage;
    public Animator flagAnimator;
    public void Start()
    {
        PlayerPrefs.SetInt("EndGame", 0);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        EngClub[0] = 6;
        EngClub[1] = 10;
        EngClub[2] = 11;
        EngClub[3] = 12;
        EngClub[4] = 18;

        _VSscr = GetComponent<VisualEffects>();
        

        EngT1 = EngClub[Random.Range(0, 4)];
        EngT2 = EngClub[Random.Range(0, 4)];



        if (PlayerPrefs.GetInt("Hit_VKL") == 0)
        {
            _info_txt.enabled = true;
        }
        else
        {
            _info_txt.enabled = false;
        }


        _NA = PlayerPrefs.GetString("NA");
        _NP = PlayerPrefs.GetString("NP");

        PlayerPrefs.GetInt("TypeGame");

        _info_txt.text = "Ход " + _NA;
        _sdacha_kart.SetActive(true);
        // _loading_Obj.transform.localPosition = new Vector3(0, 0, 0);
        MoneyScript = GameObject.Find("MoneyScript");
        change_flop.SetActive(false); _liga.SetActive(false); _country.SetActive(false); EnemyFlopPlayer.SetActive(false);
        FlopPlayer.transform.localPosition = new Vector3(_hand_x + 1400f, _hand_y, 0);
        HandPlayer.transform.localPosition = new Vector3(_hand_x, _hand_y, 0);
        _flop_btn.SetActive(true); _hand_btn.SetActive(false);
        List<GameObject> _cards_0 = GameManager.Instance._players;
        List<GameObject> _cards_1 = GameManager.Instance._playersSbor;
        for (int i = 0; i < _cards_0.Count; i++)
        {

            if (true)
            {
                if (PlayerPrefs.GetInt("TypeGame") == 0)
                {
                     if (PlayerPrefs.GetInt("Top50_VKL") == 1)
                     {

                         if ((_cards_0[i].GetComponent<PlayerScript>()._comand != 1) && (_cards_0[i].GetComponent<PlayerScript>()._comand != 9) && (_cards_0[i].GetComponent<PlayerScript>().Top50 == true) && (_cards_0[i].GetComponent<PlayerScript>()._comand != EngT1) && (_cards_0[i].GetComponent<PlayerScript>()._comand != EngT2))
                         {
                             _cards.Add(_cards_0[i]);
                         }
                     }
                     if (PlayerPrefs.GetInt("Top50_VKL") == 0)
                     {
                         if ((_cards_0[i].GetComponent<PlayerScript>()._comand != 1) && (_cards_0[i].GetComponent<PlayerScript>()._comand != 9) && (_cards_0[i].GetComponent<PlayerScript>().Top50 == false) && (_cards_0[i].GetComponent<PlayerScript>()._comand != EngT1) && (_cards_0[i].GetComponent<PlayerScript>()._comand != EngT2))
                         {
                             _cards.Add(_cards_0[i]);
                         }
                     }
                }
                


            }

        }

        for (int j = 0; j < _cards_1.Count; j++)
        {
            if (PlayerPrefs.GetInt("TypeGame") == 1)
            {
                if (PlayerPrefs.GetInt("Top50_VKL") == 1)
                {

                    if ((_cards_1[j].GetComponent<PlayerScript>()._comand != 1) && (_cards_1[j].GetComponent<PlayerScript>()._comand != 9) && (_cards_1[j].GetComponent<PlayerScript>().Top50 == true) && (_cards_1[j].GetComponent<PlayerScript>()._comand != EngT1) && (_cards_1[j].GetComponent<PlayerScript>()._comand != EngT2))
                    {
                        _cards.Add(_cards_1[j]);
                    }
                }
                if (PlayerPrefs.GetInt("Top50_VKL") == 0)
                {
                    if ((_cards_1[j].GetComponent<PlayerScript>()._comand != 1) && (_cards_1[j].GetComponent<PlayerScript>()._comand != 9) && (_cards_1[j].GetComponent<PlayerScript>().Top50 == false) && (_cards_1[j].GetComponent<PlayerScript>()._comand != EngT1) && (_cards_1[j].GetComponent<PlayerScript>()._comand != EngT2))
                    {
                        _cards.Add(_cards_1[j]);
                    }
                }
            }
        }


            foreach (var item in LinesCombination)
        {
            item.SetActive(false);
        }
        _recicler_player.SetActive(false);
        _recicler_polovina.SetActive(false);
        Invoke("CardDraw",2.1f);
        // CardDraw();


        ballAnim.SetActive(true);

        ballAnim.GetComponent<AudioSource>().Play();




    }

    void Update()
    {
        
        if (EngT1 == EngT2)
        {
            EngT2 = EngClub[Random.Range(0, 4)];
        }
    }
    public void Liga_flop_Click()
    {
        if (MoneyScript.GetComponent<MoneyScript>()._end_1_torgi && flopRaff == false && PlayerPrefs.GetInt("TypeGame") == 0)
        {
            _liga.SetActive(true);
            _country.SetActive(false);
            change_flop.SetActive(true);
            GM.GetComponent<GameManager>().Splay(0);
        }

        else if (MoneyScript.GetComponent<MoneyScript>()._end_1_torgi && flopRaff == false && PlayerPrefs.GetInt("TypeGame") == 1)
        {
            _liga.SetActive(false);
            _country.SetActive(true);
            change_flop.SetActive(true);
            GM.GetComponent<GameManager>().Splay(0);
        }

        else
        {
                _recicler_player.SetActive(true);
                _flop_btn.SetActive(false); _hand_btn.SetActive(true);
                HandPlayer.transform.localPosition = new Vector3(_hand_x - 1400f, _hand_y, 0);
                FlopPlayer.transform.localPosition = new Vector3(_hand_x, _hand_y, 0);
                EnemyFlopPlayer.SetActive(true);
                EnemyHandPlayer.SetActive(false);
                GM.GetComponent<GameManager>().Splay(0);
        }
    }

    public void Country_flop_Click()
    {

        Invoke("countryFlop", cardSpawnTime);

        EnemyFlopPlayer.SetActive(true); EnemyHandPlayer.SetActive(false);
        flopRaff = true;
        _recicler_player.SetActive(true);
        change_flop.SetActive(false);
        _flop_btn.SetActive(false); _hand_btn.SetActive(true);
        HandPlayer.transform.localPosition = new Vector3(_hand_x - 1400f, _hand_y, 0);
        FlopPlayer.transform.localPosition = new Vector3(_hand_x, _hand_y, 0);

        flagImage.sprite = GM._FlagSprites[_liga_par];
        if (_liga_par == 2)
        {
            flagAnimator.Play("IspanFlagAnim");
        }
    }

    void countryFlop()
    {

        if ((_liga_par == 0) && (_country_par == 0))
        {
            for (int i = 0; i < 3; i++)
            {
                int _number = Random.Range(0, _cards.Count);
                GameObject TempObject = Instantiate(_cards[_number]);
                Number_temp++;
                TempObject.GetComponent<PlayerScript>()._number = Number_temp;
                _cards.RemoveAt(_number);
                var collider = TempObject.GetComponent<BoxCollider2D>();
                collider.size = new Vector3(100f, 200f);
                TempObject.transform.SetParent(CardPositionFlop[i + 1].transform);
                Flop_cards.Add(TempObject);
            }
        }
        else if ((_liga_par != 0) && (_country_par != 0))
        {
            for (int i = 0; i < 3; i++)
            {
                int _number = Random.Range(0, _cards.Count);
                int iteration = 0;

                while (((_cards[_number].GetComponent<PlayerScript>()._liga != _liga_par) || (_cards[_number].GetComponent<PlayerScript>()._country != _country_par)) && (iteration < 300))
                {
                    iteration++;
                    _number = Random.Range(0, _cards.Count);
                }
                GameObject TempObject = Instantiate(_cards[_number]);
                Number_temp++;
                TempObject.GetComponent<PlayerScript>()._number = Number_temp;
                _cards.RemoveAt(_number);
                var collider = TempObject.GetComponent<BoxCollider2D>();
                collider.size = new Vector3(100f, 200f);
                TempObject.transform.SetParent(CardPositionFlop[i + 1].transform);
                Flop_cards.Add(TempObject);
            }
        }
        else if (_liga_par != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int _number = Random.Range(0, _cards.Count);
                int iteration = 0;

                while ((_cards[_number].GetComponent<PlayerScript>()._liga != _liga_par) && (iteration < 300))
                {
                    iteration++;
                    _number = Random.Range(0, _cards.Count);
                    if (iteration > 300)
                    {
                        return;
                    }
                }
                GameObject TempObject = Instantiate(_cards[_number]);
                Number_temp++;
                TempObject.GetComponent<PlayerScript>()._number = Number_temp;
                _cards.RemoveAt(_number);
                var collider = TempObject.GetComponent<BoxCollider2D>();
                collider.size = new Vector3(100f, 200f);
                TempObject.transform.SetParent(CardPositionFlop[i + 1].transform);
                Flop_cards.Add(TempObject);
            }
        }
        else if (_country_par != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                int _number = Random.Range(0, _cards.Count);
                int iteration = 0;

                while ((_cards[_number].GetComponent<PlayerScript>()._country != _country_par) && (iteration < 300))
                {
                    iteration++;
                    _number = Random.Range(0, _cards.Count);
                    if (iteration > 300)
                    {
                        return;
                    }
                }
                GameObject TempObject = Instantiate(_cards[_number]);
                Number_temp++;
                TempObject.GetComponent<PlayerScript>()._number = Number_temp;
                _cards.RemoveAt(_number);
                var collider = TempObject.GetComponent<BoxCollider2D>();
                collider.size = new Vector3(100f, 200f);
                TempObject.transform.SetParent(CardPositionFlop[i + 1].transform);
                Flop_cards.Add(TempObject);

            }
        }

        int Count_Sovpad;//определяем комбинацию врага
        for (int i = 0; i < 5; i++)
        {
            Count_Sovpad = 1;
            foreach (var item in Enemy_Cards)
            {
                if ((Enemy_Cards[i].GetComponent<PlayerScript>()._liga == item.GetComponent<PlayerScript>()._liga) && (Enemy_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number))
                {
                    // print("Count_Sovpad " + Enemy_Cards[i].GetComponent<PlayerScript>()._number);
                    //  print("Count_Sovpad " + item.GetComponent<PlayerScript>()._number);

                    Count_Sovpad++;
                }
            }
            if (Count_Sovpad > 2)
            {
                _liga_AI_flop = Enemy_Cards[i].GetComponent<PlayerScript>()._liga;
                FlopEnemy();
                return;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            Count_Sovpad = 1;
            foreach (var item in Enemy_Cards)
            {
                if ((Enemy_Cards[i].GetComponent<PlayerScript>()._liga == item.GetComponent<PlayerScript>()._liga) && (Enemy_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number))
                {
                    print("Count_Sovpad " + Enemy_Cards[i].GetComponent<PlayerScript>()._number);
                    print("Count_Sovpad " + item.GetComponent<PlayerScript>()._number);

                    Count_Sovpad++;
                }
            }
            if (Count_Sovpad == 2)
            {
                _liga_AI_flop = Enemy_Cards[i].GetComponent<PlayerScript>()._liga;
                FlopEnemy();
                return;
            }
        }
        _liga_AI_flop = 1;


        FlopEnemy();


    }

    void FlopEnemy() // заполнение флопа ИИ
    {
        for (int i = 0; i < 3; i++)
        {
            int _number = Random.Range(0, _cards.Count);
            while (_cards[_number].GetComponent<PlayerScript>()._liga != _liga_AI_flop)
            {
                _number = Random.Range(0, _cards.Count);
            }
            GameObject TempObject = Instantiate(_cards[_number]);
            TempObject.GetComponent<PlayerScript>()._number = _number;
            TempObject.GetComponent<PlayerScript>()._is_Enemy_Flop = true;
            _cards.RemoveAt(_number);
            var collider = TempObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector3(100f, 150f);
            TempObject.transform.SetParent(CardEnemyPositionFlop[i].transform);
        }
    }
    public void CardDraw()
    {
        
        for (int i = 0; i < 5; i++)
        {
            int _number = Random.Range(0, _cards.Count);
            GameObject TempObject = Instantiate(_cards[_number]);
            Number_temp++;
            TempObject.GetComponent<PlayerScript>()._number = Number_temp;
            _cards.RemoveAt(_number);
            var collider = TempObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector3(100f, 200f);
            TempObject.transform.SetParent(CardPositionHand[i].transform);
        }

        for (int i = 0; i < 5; i++)
        {
            int _number = Random.Range(0, _cards.Count);
            GameObject TempObject = Instantiate(_cards[_number]);
            Number_temp++;
            TempObject.GetComponent<PlayerScript>()._number = Number_temp;
            TempObject.GetComponent<PlayerScript>()._is_Enemy_Hand = true;
            _cards.RemoveAt(_number);
            var collider = TempObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector3(100f, 150f);
            TempObject.transform.SetParent(CardEnemyPositionHand[i].transform);
            GameObject rubashka =  Instantiate(rubashkaPrefab);
            rubashka.transform.SetParent(TempObject.transform);
            rubashka.transform.position = new Vector3(rubashka.transform.position.x + 17f, rubashka.transform.position.y + 22.5f, TempObject.transform.position.z);

        }


        for (int i = 0; i < 5; i++)         // комбинацию врага
        {
            print("добавляем");
            Enemy_Cards.Add(CardEnemyPositionHand[i].transform.GetChild(0).gameObject);
        }


        _sdacha_kart.SetActive(false);
    }    
    public void DeletFlopCart()
    {
        Invoke("DeletFlopCartEnd", 2f);
    }
    public void DeletFlopCartEnd()
    {

        

        int Count_Sovpad = 0;
        for (int i = 0; i < 3; i++) // для 5 и 4
        {
            Count_Sovpad = 1;
            foreach (var item in Flop_cards)
            {
                if ((Flop_cards[i].GetComponent<PlayerScript>()._comand ==
                     item.GetComponent<PlayerScript>()._comand) &&
                    (Flop_cards[i].GetComponent<PlayerScript>()._number !=
                     item.GetComponent<PlayerScript>()._number))
                {
                    Count_Sovpad++;
                    Sovpad.Add(item);
                }
            }
            
        }
        
        if (GM.Complexity == GameManager.Complexitys.Easy)
        {
            int _number = Random.Range(0, 100);
            CardPositionHandScript cardPosHandScript;
            cardPosHandScript = GameObject.FindObjectOfType<CardPositionHandScript>();

            if (_number <= 33)
            {
                _CartDelet = 1;
            }
            if (_number >= 33 && _number <= 66)
            {
                _CartDelet = 2;
            }
            if (_number >= 66)
            {
                _CartDelet = 3;
            }
            
        
                foreach (Transform child in CardPositionFlop[_CartDelet].transform)
                {
                    print(_number);


                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }


            


        }
        if (GM.Complexity == GameManager.Complexitys.Medium)
        {
            int _number = Random.Range(0, 100);

            if (_number <= 33)
            {
                _CartDelet = 1;
            }
            if (_number >= 33 && _number <= 66)
            {
                _CartDelet = 2;
            }
            if (_number >= 66)
            {
                _CartDelet = 3;
            }



            if (Count_Sovpad == 1)
            {

                foreach (Transform child in CardPositionFlop[_CartDelet].transform)
                {
                    print(_number);


                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
            }
            if (Count_Sovpad == 2)
            {
                int _number2 = Random.Range(0, 100);

                if (_number <= 50)
                {
                    Destroy(Sovpad[0]);
                }
                if (_number >= 51)
                {
                    Destroy(Sovpad[1]);
                }


            }
            if (Count_Sovpad == 3)
            {
                foreach (Transform child in CardPositionFlop[_CartDelet].transform)
                {
                    print(_number);


                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
            }
        }
        if (GM.Complexity == GameManager.Complexitys.Hard)
        {
            int _number = Random.Range(1, 3);
            int _number2 = Random.Range(1, 3);

            if (_number != _number2)
            {
                foreach (Transform child in CardPositionFlop[_number].transform)
                {
                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
                foreach (Transform child in CardPositionFlop[_number2].transform)
                {
                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
            }

            if (_number == _number2)
            {
                _number2++;
                foreach (Transform child in CardPositionFlop[_number].transform)
                {
                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
                foreach (Transform child in CardPositionFlop[_number2].transform)
                {
                    GameObject TempDelete = GameObject.Find(child.name);
                    Destroy(TempDelete);
                }
            }

        }


        //    GameObject Recicler_Player = GameObject.Find("Recicler_Player");
        //    Recicler_Player.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
        _recicler_player.SetActive(true);
        _recicler_polovina.SetActive(false);
        _flop_player_delete = true;
        Torgovla_END.SetActive(false);
        MoneyScript.GetComponent<MoneyScript>().TorgovlaNumbers.color = Color.white;
        _info_txt.text = "Ваш ход!";

        flop = true;
        MoneyScript.GetComponent<MoneyScript>().StartAI2();
        MoneyScript.GetComponent<MoneyScript>()._move_user = true;
    }
    public void Calculation()
    {
        for (int i = 0; i < 5; i++)
        {
            Hand_Cards[i] = CardPositionHand[i].transform.GetChild(0).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            if ((Hand_Cards[i].GetComponent<PlayerScript>()._combination_1 == 0) && (Hand_Cards[i].GetComponent<PlayerScript>()._combination_2 == 0))
            {
                foreach (var item in Hand_Cards)
                {
                    if ((Hand_Cards[i].GetComponent<PlayerScript>()._comand == item.GetComponent<PlayerScript>()._comand) && (Hand_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number))
                    {
                        //print(Hand_Cards[i].GetComponent<PlayerScript>()._number);
                        // print(item.GetComponent<PlayerScript>()._number);
                        Hand_Cards[i].GetComponent<PlayerScript>()._combination_1 = 1;
                        item.GetComponent<PlayerScript>()._combination_1 = 1;
                    }
                }
            }

            if (Hand_Cards[i].GetComponent<PlayerScript>()._combination_1 == 1)
            {
                Calculation2();
                return;
            }
        }
        Calculation2();
    }
    public void Calculation2()
    {
        for (int i = 0; i < 5; i++)
        {
            if ((Hand_Cards[i].GetComponent<PlayerScript>()._combination_1 == 0) && (Hand_Cards[i].GetComponent<PlayerScript>()._combination_2 == 0))
            {
                foreach (var item in Hand_Cards)
                {
                    if ((Hand_Cards[i].GetComponent<PlayerScript>()._comand == item.GetComponent<PlayerScript>()._comand) && (Hand_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number)&&(item.GetComponent<PlayerScript>()._combination_1 == 0))
                    {
                        //print(Hand_Cards[i].GetComponent<PlayerScript>()._number);
                        //print(item.GetComponent<PlayerScript>()._number);

                        Hand_Cards[i].GetComponent<PlayerScript>()._combination_2 = 1;
                        item.GetComponent<PlayerScript>()._combination_2 = 1;
                    }
                }
            }
        }
        foreach (var item in Hand_Cards)
        {
            if (item.GetComponent<PlayerScript>()._combination_1 == 1)
            {
                _combination_1.Add(item);
            }
            else if (item.GetComponent<PlayerScript>()._combination_2 == 1)
            {
                _combination_2.Add(item);
            }
        }
        if (_combination_1.Count == 0)
        {
            PlayerString = "Пусто";
        }
        else if (_combination_1.Count == 5)
        {
            print("у вас покер"); _info_txt.text = "у вас покер"; PlayerString = "Покер";
            _score_user = 6;
        }
        else if (_combination_1.Count == 4)
        {
            print("у вас каре"); _info_txt.text = "у вас каре"; PlayerString = "Каре";
            _score_user = 5;
        }
        else if (((_combination_1.Count == 3) && (_combination_2.Count == 2)) || ((_combination_1.Count == 2) && (_combination_2.Count == 3)))
        {
            print("у вас 2+3"); _info_txt.text = "у вас 2+3"; PlayerString = "2 + 3";
            _score_user = 4;
        }
        else if ((_combination_1.Count == 2) && (_combination_2.Count == 2))
        {
            print("у вас две двойки"); _info_txt.text = "у вас две двойки"; PlayerString = "Две пары";
            _score_user = 3;
        }
        else if ((_combination_1.Count == 3) || (_combination_2.Count == 3))
        {
            print("у вас тройка"); _info_txt.text = "у вас тройка"; PlayerString = "Тройка";
            _score_user = 2;
        }
        else if ((_combination_1.Count == 2) || (_combination_2.Count == 2))
        {
            print("у вас двойка"); _info_txt.text = "у вас двойка"; PlayerString = "Двойка";
            _score_user = 1;
        }
        Calculation3();
    }
    void Calculation3()
    {        
        for (int i = 0; i < 3; i++)
        {
            if (CardEnemyPositionFlop[i].transform.childCount >= 1)
            {
                Enemy_Cards.Add(CardEnemyPositionFlop[i].transform.GetChild(0).gameObject);
            }
        }

        for (int i = 0; i < 7; i++)
        {
            if ((Enemy_Cards[i].GetComponent<PlayerScript>()._combination_1 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_2 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_3 == 0))
            {
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand == item.GetComponent<PlayerScript>()._comand) && (Enemy_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number) && (item.GetComponent<PlayerScript>()._combination_1 == 0))
                    {
                      //  print("_combination_1 " + Enemy_Cards[i].GetComponent<PlayerScript>()._number);
                      //  print("_combination_1 " + item.GetComponent<PlayerScript>()._number);

                        Enemy_Cards[i].GetComponent<PlayerScript>()._combination_1 = 1;
                        item.GetComponent<PlayerScript>()._combination_1 = 1;
                    }
                }
            }

            if (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_1 == 1)
            {
                Calculation4();
                return;
            }
        }
        Calculation4();
    }
    void Calculation4()
    {
        for (int i = 0; i < 7; i++)
        {
            if ((Enemy_Cards[i].GetComponent<PlayerScript>()._combination_1 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_2 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_3 == 0))
            {
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand == item.GetComponent<PlayerScript>()._comand) && (Enemy_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number) && (item.GetComponent<PlayerScript>()._combination_1 == 0) && (item.GetComponent<PlayerScript>()._combination_2 == 0))
                    {
                      //  print("_combination_2 " + Enemy_Cards[i].GetComponent<PlayerScript>()._number);
                      //  print("_combination_2 " + item.GetComponent<PlayerScript>()._number);

                        Enemy_Cards[i].GetComponent<PlayerScript>()._combination_2 = 1;
                        item.GetComponent<PlayerScript>()._combination_2 = 1;
                    }
                }
            }

            if (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_2 == 1)
            {
                Calculation5();
                return;
            }
        }
        Calculation5();
    }
    void Calculation5()
    {
        for (int i = 0; i < 7; i++)
        {
            if ((Enemy_Cards[i].GetComponent<PlayerScript>()._combination_1 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_2 == 0) && (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_3 == 0))
            {
                foreach (var item in Enemy_Cards)
                {
                    if ((Enemy_Cards[i].GetComponent<PlayerScript>()._comand == item.GetComponent<PlayerScript>()._comand) && (Enemy_Cards[i].GetComponent<PlayerScript>()._number != item.GetComponent<PlayerScript>()._number) && (item.GetComponent<PlayerScript>()._combination_1 == 0) && (item.GetComponent<PlayerScript>()._combination_2 == 0) && (item.GetComponent<PlayerScript>()._combination_3 == 0))
                    {
                        print("_combination_3 " + Enemy_Cards[i].GetComponent<PlayerScript>()._number);
                        print("_combination_3 " + item.GetComponent<PlayerScript>()._number);

                        Enemy_Cards[i].GetComponent<PlayerScript>()._combination_3 = 1;
                        item.GetComponent<PlayerScript>()._combination_3 = 1;
                    }
                }
            }

            if (Enemy_Cards[i].GetComponent<PlayerScript>()._combination_3 == 1)
            {
                Calculation6();
                return;
            }
        }
        Calculation6();
    }
    void Calculation6()
    {
        foreach (var item in Enemy_Cards)
        {
            if (item.GetComponent<PlayerScript>()._combination_1 == 1)
            {
                _enemy_combination_1.Add(item);
            }
            else if (item.GetComponent<PlayerScript>()._combination_2 == 1)
            {
                _enemy_combination_2.Add(item);
            }
            else if (item.GetComponent<PlayerScript>()._combination_3 == 1)
            {
                _enemy_combination_3.Add(item);
            }
        }




        if (_enemy_combination_1.Count == 0)            //у АИ ничего нет
        {
            print("у " +_NA+ " ничего нет");
            _score_AI = 0; AIString = "Пусто";
        }
        else if (_enemy_combination_2.Count == 0)           //у АИ 1 комбинация
        {
            if (_enemy_combination_1.Count == 5)
            {
                print("у " + _NA + " покер"); _info_txt.text = "у " + _NA + " покер";
                _score_AI = 6; AIString = "Покер";
            }
            else if (_enemy_combination_1.Count == 4)
            {
                print("у " + _NA + " каре"); _info_txt.text = "у " + _NA + " каре";
                _score_AI = 5; AIString = "Каре";
            }
            else if (_enemy_combination_1.Count == 3)
            {
                print("у " + _NA + " тройка"); _info_txt.text = "у " + _NA + " тройка";
                _score_AI = 2; AIString = "Тройка";
            }
            else if (_enemy_combination_1.Count == 2)
            {
                print("у " + _NA + " двойка"); _info_txt.text = "у " + _NA + " двойка";
                _score_AI = 1; AIString = "Двойка";
            }
            Calculation7();
            return;
        }
        else if (_enemy_combination_3.Count == 0)           //у АИ 2 комбинации
        {
            //делим на главную комбинацию и вторую, поменьше
            if (_enemy_combination_1.Count > _enemy_combination_2.Count)
            {
                _main_enemy_combination = _enemy_combination_1;
                _second_enemy_combination = _enemy_combination_2;
                if (_main_enemy_combination.Count == 5)
                {
                    print("у " + _NA + " покер"); _info_txt.text = "у " + _NA + " покер";
                    _score_AI = 6; AIString = "Покер";
                    Calculation7();
                    return;
                }
                else if (_main_enemy_combination.Count == 4)
                {
                    print("у " + _NA + " каре"); _info_txt.text = "у " + _NA + " каре";
                    _score_AI = 5; AIString = "Каре";
                    Calculation7();
                    return;
                }
            }
            else if (_enemy_combination_2.Count > _enemy_combination_1.Count)
            {
                _main_enemy_combination = _enemy_combination_2;
                _second_enemy_combination = _enemy_combination_1;
                if (_main_enemy_combination.Count == 5)
                {
                    print("у " + _NA + " покер"); _info_txt.text = "у " + _NA + " покер";
                    _score_AI = 6; AIString = "Покер";
                    Calculation7();
                    return;
                }
                else if (_main_enemy_combination.Count == 4)
                {
                    print("у " + _NA + " каре"); _info_txt.text = "у " + _NA + " каре";
                    _score_AI = 5; AIString = "Каре";
                    Calculation7();
                    return;
                }
            }

            if (_enemy_combination_1.Count != _enemy_combination_2.Count)       //если 3 + 2;  варианты 4+2 5+2 4+3 исключили выше
            {
                print("у " + _NA + " 2+3"); _info_txt.text = "у " + _NA + " 2+3";
                _score_AI = 4; AIString = "2 + 3";
            }


            if (_enemy_combination_1.Count == _enemy_combination_2.Count)   //если 2 двойки или две тройки
            {
                _main_enemy_combination = _enemy_combination_1;
                if (_enemy_combination_1.Count == 3)
                {
                    print("у " + _NA + " тройка"); _info_txt.text = "у " + _NA + " тройка";
                    _score_AI = 2; AIString = "Тройка";
                }
                else
                {
                    print("у " + _NA + " две двойки"); _info_txt.text = "у " + _NA + " две двойки";
                    _score_AI = 3; AIString = "Две пары";
                }
                Calculation7();
                return;
            }
        }
        else
        {
            print("у " + _NA + " 3 комбинации");
            //   2 2 2
            //   2 2 3
            if (_enemy_combination_1.Count > _enemy_combination_2.Count)
            {
                _main_enemy_combination = _enemy_combination_1;
            }
            else  //либо 2 больше 1 либо равны. если равны - не важнокто юудет главным
            {
                _main_enemy_combination = _enemy_combination_2;
            }

            // местоположение в иерархии 3-го
            if (_main_enemy_combination.Count > _enemy_combination_2.Count)
            {
                print("у " + _NA + " 2+3"); _info_txt.text = "у " + _NA + " 2+3";
                _score_AI = 4; AIString = "2 + 3";
            }
            else if (_main_enemy_combination.Count < _enemy_combination_2.Count)
            {
                print("у " + _NA + " 2+3"); _info_txt.text = "у " + _NA + " 2+3";
                _score_AI = 4; AIString = "2 +3";
            }
            else if ((_enemy_combination_1.Count == _enemy_combination_1.Count)&&(_enemy_combination_1.Count == _enemy_combination_1.Count))
            {
                print("у " + _NA + " две двойки"); _info_txt.text = "у " + _NA + " две двойки";
                _score_AI = 3; AIString = "Две пары";
            }
        }
        Calculation7();
    }
    void Calculation7()
    {
        MoneyScript moneyScr;
        moneyScr = GetComponent<MoneyScript>();

        string PlayerResult = "";
        if (_score_AI == _score_user)
        {
            
            PlayerResult = "поровну";
            /*int T = MoneyScript.GetComponent<MoneyScript>()._stavka /= 2;
            MoneyScript.GetComponent<MoneyScript>()._all_money_AI += T;
            MoneyScript.GetComponent<MoneyScript>()._all_money_user += T;*/

            int HingWorldRatingEnemy;
            int HingWorldRatingPlayer;

            if (_enemy_combination_1 != null)
            {
                for (int i = 0; i < _enemy_combination_1.Count; i++)
                {
                    EnemyT.Add(_enemy_combination_1[i].GetComponent<PlayerScript>().WorldRayting);
                }
            }
        
            if (_enemy_combination_2 != null)
            {
                for (int i = 0; i < _enemy_combination_2.Count; i++)
                {
                    EnemyT.Add(_enemy_combination_2[i].GetComponent<PlayerScript>().WorldRayting);
                }
            }

            if (_enemy_combination_3 != null)
            {
                for (int i = 0; i < _enemy_combination_3.Count; i++)
                {
                    EnemyT.Add(_enemy_combination_3[i].GetComponent<PlayerScript>().WorldRayting);
                }
            }
           
            if (_combination_1 != null)
            {
                for (int i = 0; i < _combination_1.Count; i++)
                {
                    PlayerT.Add(_combination_1[i].GetComponent<PlayerScript>().WorldRayting);
                }
            }

            if (_combination_2 != null)
            {
                for (int i = 0; i < _combination_2.Count; i++)
                {
                    PlayerT.Add(_combination_2[i].GetComponent<PlayerScript>().WorldRayting);
                }
            }
            
            
            PlayerT.Sort();
            PlayerT.Reverse();
            EnemyT.Sort();
            EnemyT.Reverse();
            HingWorldRatingEnemy = EnemyT[0];
            HingWorldRatingPlayer = PlayerT[0];


            if (HingWorldRatingPlayer<HingWorldRatingEnemy)
            {
                PlayerResult = "Вы выиграли";
                MoneyScript.GetComponent<MoneyScript>()._all_money_user += MoneyScript.GetComponent<MoneyScript>()._stavka;
                animImage.sprite = _HPWords[3];
                win = true;
                GM.GetComponent<GameManager>().Splay(7);

                _TorgObj.SetActive(false);
                _Eflop.SetActive(true);
                _EFlopFinish.SetTrigger("Finish");
                PlayerPrefs.SetInt("EndGame", 1);
                _VSscr.end();

                Invoke("EndOfRound", 3f);
            }
            else
            {
                PlayerResult = "Вы проиграли";
                MoneyScript.GetComponent<MoneyScript>()._all_money_AI += MoneyScript.GetComponent<MoneyScript>()._stavka;
                animImage.sprite = _HPWords[4];
                win = false;
                GM.GetComponent<GameManager>().Splay(8);

                _TorgObj.SetActive(false);
                _Eflop.SetActive(true);
                _EFlopFinish.SetTrigger("Finish");
                PlayerPrefs.SetInt("EndGame", 1);
                _VSscr.end();


                Invoke("EndOfRound", 3f);
            }
            
            
            
            

        }
        else if (_score_AI > _score_user)
        {
            PlayerResult = "Вы проиграли";

            MoneyScript.GetComponent<MoneyScript>()._all_money_AI += MoneyScript.GetComponent<MoneyScript>()._stavka;
            
            animImage.sprite = _HPWords[4];
            win = false;
            GM.GetComponent<GameManager>().Splay(8);

            _TorgObj.SetActive(false);
            _Eflop.SetActive(true);
            _EFlopFinish.SetTrigger("Finish");
            PlayerPrefs.SetInt("EndGame", 1);
            _VSscr.end();

            Invoke("EndOfRound", 3f);
        }
        else if (_score_AI < _score_user)
        {
            PlayerResult = "Вы выиграли";
            MoneyScript.GetComponent<MoneyScript>()._all_money_user += MoneyScript.GetComponent<MoneyScript>()._stavka;

            animImage.sprite = _HPWords[3];
            win = true;
            GM.GetComponent<GameManager>().Splay(7);

            _TorgObj.SetActive(false);
            _Eflop.SetActive(true);
            _EFlopFinish.SetTrigger("Finish");
            PlayerPrefs.SetInt("EndGame", 1);
            _VSscr.end();
            Invoke("GO", 1f);

            Invoke("EndOfRound", 3f);
        }

        _info_txt.text = "У Вас: " + PlayerString + "; у " + _NA + AIString + "; " + PlayerResult;

        if (_enemy_combination_1 != null)
        {
            for (int i = 0; i < _enemy_combination_1.Count; i++)
            {
                Sortfineshcart.Add(_enemy_combination_1[i]);
            }
        }
        
        if (_enemy_combination_2 != null)
        {
            for (int i = 0; i < _enemy_combination_2.Count; i++)
            {
                Sortfineshcart.Add(_enemy_combination_2[i]);
            }
        }

        if (_enemy_combination_3 != null)
        {
            for (int i = 0; i < _enemy_combination_3.Count; i++)
            {
                Sortfineshcart.Add(_enemy_combination_3[i]);
            }
        }


        for (int i = 0; i < CardEnemyPositionHand.Count; i++)
        {
            Sortfineshcart.Add(CardEnemyPositionHand[i].transform.GetChild(0).gameObject);
        }

        for (int i = 0; i <Sortfineshcart.Count; i ++) // Внешний цикл - это число циклов
        {
            for (int j = Sortfineshcart.Count-1; j> i; j--) // Внутренний цикл - это количество раз, которое внешний цикл сравнивается
            {

                if (Sortfineshcart[i] == Sortfineshcart[j])
                {
                    Sortfineshcart.RemoveAt(j);
                }

            }
        }
        
        
        
        GameObject Hand = GameObject.Find("EnemyHandPlayer");
        Hand.SetActive(false);
        Finish.SetActive(true);
        for (int i = 0; i < Sortfineshcart.Count; i++)
        {
            GameObject TempObject = Instantiate(Sortfineshcart[i]);
            Number_temp++;
            TempObject.GetComponent<PlayerScript>()._number = Number_temp;
            TempObject.GetComponent<PlayerScript>()._is_Enemy_Hand = true;
            var collider = TempObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector3(100f, 150f);
            TempObject.transform.SetParent(CardEnemyPositionHandFinish[i].transform);

        }








    }
    
    void FlopDraw_1_2()
    {
        int _number = Random.Range(0, _cards.Count);
        if ((_cards[_number].GetComponent<PlayerScript>()._liga == _liga_par) && (_cards[_number].GetComponent<PlayerScript>()._country == _country_par))
        {
            GameObject TempObject = Instantiate(_cards[_number]);
            TempObject.GetComponent<PlayerScript>()._number = _number;
            _cards.RemoveAt(_number);
            var collider = TempObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector3(100f, 200f);
            TempObject.transform.SetParent(FlopPlayer.transform);
        }
        else
        {
            FlopDraw_1_2();
        }
    }
    public void GoFlop()
    {
        if (MoneyScript.GetComponent<MoneyScript>()._end_1_torgi)
        {
            if (_change_flop)
            {
                _hand_btn.SetActive(true);
                _recicler_player.SetActive(true);
                HandPlayer.transform.localPosition = new Vector3(_hand_x - 1400f, _hand_y, 0);
                FlopPlayer.transform.localPosition = new Vector3(_hand_x, _hand_y, 0);
            }
            else
            {
                change_flop.SetActive(true); /*_liga.SetActive(true);*/
                _change_flop = true;
                Country_flop_Click();
            }
            _flop_btn.SetActive(false);
            EnemyFlopPlayer.SetActive(true); EnemyHandPlayer.SetActive(false);
        }
    }
    public void GoHand()
    {
            GM.GetComponent<GameManager>().Splay(0);
            _recicler_player.SetActive(false);
            _flop_btn.SetActive(true); _hand_btn.SetActive(false);
            HandPlayer.transform.localPosition = new Vector3(_hand_x, _hand_y, 0);
            FlopPlayer.transform.localPosition = new Vector3(_hand_x + 1400f, _hand_y, 0);
            EnemyFlopPlayer.SetActive(false);
            EnemyHandPlayer.SetActive(true);
        
    }

    public void EndOfRound()
    {

        if (MoneyScript.GetComponent<MoneyScript>().aiPass)
        {
            if (PlayerPrefs.GetInt("EnemyPass") == 1)
            {
                GM.GetComponent<GameManager>().Splay(6);

                animImage.sprite = _HPWords[1];
                _VSscr.end();
                Invoke("enemyPass", 3f);
            }
        }
        else if (win)
        {

            nRPanel.SetActive(true);
        }
        else if(!win)
        {

            nRPanel.SetActive(true);
        }
    }

    void enemyPass()
    {
        nRPanel.SetActive(true);
    }

    void GO()
    {
        flop = false;
    }

    public void FlopAnim()
    {
        flipAnim.SetActive(true);
        Invoke("switchOffAnim", cardSpawnTime);
    }

    void switchOffAnim()
    {
        flipAnim.SetActive(false);
    }
}
