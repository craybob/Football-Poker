using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public int _DelCartEnemy;
    public bool _DelCart;



    public void DeletyCartEnemy()
    {
        _DelCart = true;
    }


    private void Update()
    {
        if (_DelCartEnemy <= 0)
        {
            _DelCart = false; 
        }
    }
}
