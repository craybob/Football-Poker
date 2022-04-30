using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public InputField _NamePlayer;
    public InputField _NameAi;
    public Toggle[] _Hin;


    void Awake()
    {
        _Hin[9].isOn = true;
    }

    private void Start()
    {
        _NamePlayer.text = PlayerPrefs.GetString("NP");
        _NameAi.text = PlayerPrefs.GetString("NA");

        if (PlayerPrefs.GetInt("Hit_VKL") == 0)
        {
            _Hin[1].isOn = true;
        }else
        {
            _Hin[1].isOn = false;
        } //Подсказки

        if (PlayerPrefs.GetInt("VEff_VKL") == 0)
        {
            _Hin[4].isOn = true;
        }else
        {
            _Hin[4].isOn = false;
        } //ВизЭфект

        if (PlayerPrefs.GetInt("Top50_VKL") == 1)
        {
            _Hin[3].isOn = true;
        }
        else
        {
            _Hin[3].isOn = false;
        } // Top 50

        if (PlayerPrefs.GetInt("NP_VKL") == 0)
        {
            _Hin[0].isOn = true;
        }
        else
        {
            _Hin[0].isOn = false;
        }

        if (PlayerPrefs.GetInt("NT_VKL") == 0)
        {
            _Hin[2].isOn = true;
        }
        else
        {
            _Hin[2].isOn = false;
        }

        if (PlayerPrefs.GetInt("Music_VKL") == 0)
        {
            _Hin[6].isOn = true;
        }
        else
        {
            _Hin[6].isOn = false;
        }


        if (PlayerPrefs.GetInt("Audio_VKL") == 0)
        {
            _Hin[5].isOn = true;
            GetComponent<AudioSource>().mute = false;
        }
        else
        {
            _Hin[5].isOn = false;
            GetComponent<AudioSource>().mute = true;
        }

        if (PlayerPrefs.GetInt("TypeGame") == 1)
        {
            _Hin[11].isOn = true;
        }
        else
        {
            _Hin[11].isOn = false;
        }

        if (PlayerPrefs.GetInt("TypeGame") == 0)
        {
            _Hin[12].isOn = true;
        }
        else
        {
            _Hin[12].isOn = false;
        }
    }

    private void Update()
    {
        PlayerPrefs.SetString("NP", _NamePlayer.text);
        PlayerPrefs.SetString("NA", _NameAi.text);
    }

    public void Hints()//Подсказки
    {
       
            if (_Hin[1].isOn == true)
            {
                int Hin = 0;
                PlayerPrefs.SetInt("Hit_VKL", Hin);
            }

            if (_Hin[1].isOn == false)
            {
                int Hin = 1;
                PlayerPrefs.SetInt("Hit_VKL", Hin);
            }
        


        
    }

    public void CardPlayerName()
    {
        if (_Hin[0].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("NP_VKL", Hin);
        }

        if (_Hin[0].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("NP_VKL", Hin);
        }
    }

    public void CardTeamName()
    {
        if (_Hin[2].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("NT_VKL", Hin);
        }

        if (_Hin[2].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("NT_VKL", Hin);
        }
    }

    public void Top50()
    {
        if (_Hin[3].isOn == true)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("Top50_VKL", Hin);
            //GameObject.Find("GameManager").GetComponent<GameManager>()._players = GameObject.Find("GameManager").GetComponent<GameManager>()._playersT50;
        }

        if (_Hin[3].isOn == false)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("Top50_VKL", Hin);
            //GameObject.Find("GameManager").GetComponent<GameManager>()._players = GameObject.Find("GameManager").GetComponent<GameManager>()._playersCart;
        }
    }


    public void VideoEffect()
    {
        if (_Hin[4].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("VEff_VKL", Hin);
        }

        if (_Hin[4].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("VEff_VKL", Hin);
        }
    }

    public void MusicEffect()
    {
        if (_Hin[6].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("Music_VKL", Hin);
        }

        if (_Hin[6].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("Music_VKL", Hin);
        }
    }


    public void AudioEffect()
    {
        if (_Hin[5].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("Audio_VKL", Hin);
            GetComponent<AudioSource>().mute = false;
        }

        if (_Hin[5].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("Audio_VKL", Hin);
            GetComponent<AudioSource>().mute = true;
        }
    }

    public void Sbornaya()
    {
        if (_Hin[8].isOn == true)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("TypeGame", Hin);
            _Hin[9].isOn = false;
        }

        if (_Hin[8].isOn == false)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("TypeGame", Hin);
            _Hin[9].isOn = true;
        }
    }

    public void Liga()
    {
        if (_Hin[9].isOn == true)
        {
            int Hin = 0;
            PlayerPrefs.SetInt("TypeGame", Hin);
            _Hin[8].isOn = false;
        }

        if (_Hin[9].isOn == false)
        {
            int Hin = 1;
            PlayerPrefs.SetInt("TypeGame", Hin);
            _Hin[8].isOn = true;
        }

    }

}
    
