using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Complexitys
    {
        Easy,
        Medium,
        Hard
    }


    public List<GameObject> _players = new List<GameObject>();

    public List<GameObject> _playersSbor = new List<GameObject>();

    public AudioClip[] _AudioC;
    public AudioSource _AudioS;

    public Sprite[] _FlagSprites;
    public Complexitys Complexity;


    public int _difficulty;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static GameManager instance = null;


    void Awake()
    {
        _AudioS = GetComponent<AudioSource>();

        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Music_VKL") == 0)
        {
            GetComponent<AudioSource>().mute = false;
        }
        if (PlayerPrefs.GetInt("Music_VKL") == 1)
        {
            GetComponent<AudioSource>().mute = true;
        }

        if (_difficulty == 1)
        {
            Complexity = Complexitys.Easy;
        }

        if (_difficulty == 2)
        {
            Complexity = Complexitys.Medium;
        }

        if (_difficulty == 3)
        {
            Complexity = Complexitys.Hard;
        }

    }

    public void Splay(int whatSound)
    {
        _AudioS.PlayOneShot(_AudioC[whatSound]);
    }

    public void EnemyCardBtn()
    {
        _AudioS.PlayOneShot(_AudioC[12]);
    }
}
