using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Music Effects")]
    GameObject GM;

    // Start is called before the first frame update
    void Awake()
    {
        GM = GameObject.Find("GameManager");
    }

    public void enemybtn(int sound)
    {
        GM.GetComponent<GameManager>().Splay(sound);
    }
}
