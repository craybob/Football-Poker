using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{

    public List<int> SortCartEnemy;



    void Start()
    {

        Test();

    }

    void Test()
    {

        for (int i = 0; i < 5; i++)
        {
            int _number = Random.Range(0, 100);
            SortCartEnemy.Add(_number);
        }
        SortCartEnemy.Sort();
    }
}
