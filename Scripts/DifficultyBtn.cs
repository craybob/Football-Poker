using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyBtn : MonoBehaviour
{
    public int _diffiulty;
    public GameObject[] Lvl;
    //Vector4 _color = new Color(0.6f, 0.6f, 0.6f, 1f);
    public Vector4 _color;
    GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }





    public void LvLSelect()
    {
        _diffiulty++;

        switch (_diffiulty)
        {
            case 2:
                Lvl[0].SetActive(false);
                Lvl[1].SetActive(true);
                Lvl[2].SetActive(false);
                _diffiulty = 2;
                break;

            case 3:
                Lvl[0].SetActive(false);
                Lvl[1].SetActive(false);
                Lvl[2].SetActive(true);
                _diffiulty = 3;
                break;


            default:
                Lvl[0].SetActive(true);
                Lvl[1].SetActive(false);
                Lvl[2].SetActive(false);
                _diffiulty = 1;
                break;
        }

        
    }


    void Update()
    {
        GM._difficulty = _diffiulty;
    }
}
