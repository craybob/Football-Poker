using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    GameObject GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager");

        if (PlayerPrefs.GetInt("Audio_VKL") == 0)
        {
            GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GetComponent<AudioSource>().mute = true;
        }
    }

    public void StartGame(string _scena)
    {
        SceneManager.LoadScene(_scena);
        GM.GetComponent<GameManager>().Splay(1);
        //GameManager.Instance.CountPlayer = 2;
    }
    public void NewGame(string _scena)
    {
        GameObject.Find("MoneyScript").GetComponent<MoneyScript>()._all_money_AI = 990;
        GameObject.Find("MoneyScript").GetComponent<MoneyScript>()._all_money_user = 990;
        SceneManager.LoadScene(_scena);
        
    }


    public void Exit()
    {
        Application.Quit();
    }
}

