using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject GameSceneScript;
    public static GameObject item;
    Vector3 startPosition;
    Transform startParent;
    public GameObject TargetCard;

    TorgovlyaAnimation[] torgAnim;
    MoneyScript moneyScr;

    public GameObject _GMscr;

    private void Awake()
    {
        GameSceneScript = GameObject.Find("GameSceneScript");
        _GMscr = GameObject.Find("GameManager");
        torgAnim = FindObjectsOfType<TorgovlyaAnimation>();
        moneyScr = FindObjectOfType<MoneyScript>();
    }

    private void Start()
    {
        if (GetComponent<PlayerScript>()._arbitr == 1)//если это  судья
        {
            for (int i = 1; i < GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand.Count; i++)
            {
                if (GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i].name == transform.parent.name)//узнали того куда бросаем
                {
                    print(GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i].name);
                    
                    //получить потомка карты слева

                    print(GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand);
                    GetComponent<PlayerScript>()._comand = GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand;
                    GetComponent<PlayerScript>()._comand_txt.text = GetComponent<PlayerScript>()._comand.ToString();

                }
            }
        }
        
        if (GetComponent<PlayerScript>()._arbitr == 1)//если это  судья
        {
            for (int i = 1; i < GameSceneScript.GetComponent<GameSceneScript>().CardEnemyPositionHand.Count; i++)
            {
                if (GameSceneScript.GetComponent<GameSceneScript>().CardEnemyPositionHand[i].name == transform.parent.name)//узнали того куда бросаем
                {
                    print(GameSceneScript.GetComponent<GameSceneScript>().CardEnemyPositionHand[i].name);
                    
                    //получить потомка карты слева

                    print(GameSceneScript.GetComponent<GameSceneScript>().CardEnemyPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand);
                    GetComponent<PlayerScript>()._comand = GameSceneScript.GetComponent<GameSceneScript>().CardEnemyPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand;
                    GetComponent<PlayerScript>()._comand_txt.text = GetComponent<PlayerScript>()._comand.ToString();

                }
            }
        }
        
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GetComponent<PlayerScript>()._is_Enemy_Hand)
        {
            item = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(transform.root);

            _GMscr.GetComponent<GameManager>().Splay(0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _GMscr.GetComponent<GameManager>().Splay(1);
        if (!GetComponent<PlayerScript>()._is_Enemy_Hand) 
        {
            if (!GetComponent<PlayerScript>()._is_Enemy_Flop)//если это не флоп болвана
            {
                item = null;
                
                if ((TargetCard != null) && (TargetCard.name != "Hand_btn") && (TargetCard.name != "Recicler_Enemy") && (TargetCard.name != "Recicler_Player"))
                {
                    if ((TargetCard.GetComponent<PlayerScript>()._is_Enemy_Hand) || (TargetCard.GetComponent<PlayerScript>()._is_Enemy_Flop)) //если карта не игрока
                    {
                        transform.SetParent(startParent);
                    }
                    else
                    {
                        transform.SetParent(TargetCard.transform.parent);
                        TargetCard.transform.SetParent(startParent);
                    }

                }
                else if (transform.parent == startParent || transform.parent == transform.root)         //когда мимо карты бросаем
                {
                    //   transform.position = startPosition;
                    transform.SetParent(startParent);
                }

            }
            else//если это флоп болвана
            {
                transform.SetParent(startParent);
                _GMscr.GetComponent<GameManager>().Splay(4);
                if ((TargetCard.name == "Recicler_Player") && !GameSceneScript.GetComponent<GameSceneScript>()._flop_enemy_delet)
                {
                    GameSceneScript.GetComponent<GameSceneScript>()._flop_enemy_delet = true;
                    TargetCard.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
                    TargetCard.SetActive(false);
                    GameSceneScript.GetComponent<GameSceneScript>()._recicler_polovina.SetActive(true);
                    moneyScr.GetComponent<MoneyScript>().checkBtn.GetComponent<Button>().enabled = true;
                    
                    for(int i = 0; i < torgAnim.Length; i++)
                    {
                        torgAnim[i].GetComponent<TorgovlyaAnimation>().animPlay = true;
                    }

                    //GameObject Recicler_Enemy = GameObject.Find("Recicler_Enemy");
                    //Recicler_Enemy.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
                    GameSceneScript.GetComponent<GameSceneScript>().DeletFlopCart();
                    Destroy(gameObject);
                }
            }
        }

        if (GetComponent<PlayerScript>()._arbitr == 1)//если это  судья
        {
            for (int i = 1; i < GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand.Count; i++)
            {
                if (GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i].name == transform.parent.name)//узнали того куда бросаем
                {
                    print(GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i].name);
                    print("YRA");
                    //получить потомка карты слева

                    print(GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand);
                    GetComponent<PlayerScript>()._comand = GameSceneScript.GetComponent<GameSceneScript>().CardPositionHand[i - 1].transform.GetChild(0).gameObject.GetComponent<PlayerScript>()._comand;
                    GetComponent<PlayerScript>()._comand_txt.text = GetComponent<PlayerScript>()._comand.ToString();
                    // print

                    //  if (true)
                    //  {
                    //
                    //   }
                }
            }
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!GetComponent<PlayerScript>()._is_Enemy_Hand)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<PlayerScript>()._is_Enemy_Flop)
        {

        }
        if ((collision.name == "Hand_btn") && (GameSceneScript.GetComponent<GameSceneScript>()._flop_enemy_delet) && (GameSceneScript.GetComponent<GameSceneScript>()._flop_player_delete))
        {
            GameSceneScript.GetComponent<GameSceneScript>().GoHand();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetCard = null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TargetCard = collision.gameObject;

    }
    
    
}