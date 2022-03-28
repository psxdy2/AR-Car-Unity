using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuView : MonoBehaviour
{

    public Transform mNoticeView;

    private void Awake()
    {
        mNoticeView.gameObject.SetActive(false);
    }

    public void OnSceneButtonEvent()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnInViewButtonEvent()
    {
        mNoticeView.gameObject.SetActive(true);
    }
    
    public void OnQuitButtonEvent()
    {
        Application.Quit();
    }

    public void CloseButtonEvent()
    {
        mNoticeView.gameObject.SetActive(false);
    }
    
}
