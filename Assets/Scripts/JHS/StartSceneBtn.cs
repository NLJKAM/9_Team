using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneBtn : MonoBehaviour
{

    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
