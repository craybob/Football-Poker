using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEffects : MonoBehaviour
{
    public Animator Headpiece;
    GameSceneScript _GMScript;

    public Sprite[] _BallAnimWords;
    public Image animTarget;
    public bool win;
    public bool flop;
    public bool pass;

    // Start is called before the first frame update
    void Awake()
    {
        _GMScript = GetComponent<GameSceneScript>();

        if (PlayerPrefs.GetInt("Audio_VKL") == 0)
        {
            Headpiece.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            Headpiece.GetComponent<AudioSource>().mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void end()
    {
        Headpiece.SetTrigger("on");
        Headpiece.GetComponent<AudioSource>().Play();
    }
}
