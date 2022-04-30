using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    void Start()
    {
        Invoke("StartScene", 2f);
    }
    void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
