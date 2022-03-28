using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainView : MonoBehaviour
{

    public ModelControl mModel;
    
    public void OnRotateLeftAndRightButtonEvent(bool isLeft)
    {
        mModel.Rotate(isLeft);
    }
    
    public void OnMoveLeftAndRightButtonEvent(bool isLeft)
    {
        mModel.Move(isLeft);
    }

    public void OnScaleButtonEvent(bool isClose)
    {
        mModel.MoveCamera(isClose);
    }

    public void ResetButtonEvent()
    {
        mModel.ResetViews();
    }

    public void MenuButtonEvent()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
