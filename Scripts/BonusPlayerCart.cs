using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BonusPlayerCart : MonoBehaviour, IPointerDownHandler
{
    private MoneyScript Money;
    private BonusManager BM;
    
    private void Start()
    {
        Money = GameObject.Find("MoneyScript").GetComponent<MoneyScript>();
        BM = GameObject.Find("MoneyScript").GetComponent<BonusManager>();
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (BM._DelCart == true)
        {
            int T = Random.Range(50,999);
            gameObject.transform.GetChild(0).GetComponent<PlayerScript>()._comand = T;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Money.StartAI();
            BM._DelCart = false;
            BM._DelCartEnemy--;
        }
        
    }
    
}
