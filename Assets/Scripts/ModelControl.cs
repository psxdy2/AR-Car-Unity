using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ModelControl : MonoBehaviour
{

    [Header("旋转速度")]
    public float mRotateSpeed = 10;

    [Header("水平移动速度")]
    public float mMoveSpeed = 5;

    [Header("相机移动速度")]
    public float mScaleSpeed = 0.5f;

    public Camera mCamera;

    private Vector3 mCameraPos;

    private Vector3 mSelfPos;

    private Vector3 mSlefRo;

    private void Awake()
    {
        mCameraPos = mCamera.transform.position;
        mSelfPos = transform.position;
        mSlefRo = transform.localRotation.eulerAngles;
    }

    private void OnDestroy()
    {
        KillTweener();
    }

    private Tweener _rotateTweener;
    public void Rotate(bool isLeft)
    {
        if (isLeft)
        {
            _rotateTweener = transform.DOLocalRotate(new Vector3(0, mRotateSpeed, 0) + transform.localRotation.eulerAngles, 0.5f, RotateMode.FastBeyond360);
        }
        else
        {
            _rotateTweener = transform.DOLocalRotate(new Vector3(0, -mRotateSpeed, 0) + transform.localRotation.eulerAngles, 0.5f, RotateMode.FastBeyond360);
        }
        
    }
    
    private Tweener _moveTweener;
    public void Move(bool isLeft)
    {
        _moveTweener?.Kill();
        if (isLeft)
        {
            _moveTweener = transform.DOMoveX(transform.position.x - mMoveSpeed, 0.5f);
        }
        else
        {
            _moveTweener = transform.DOMoveX(transform.position.x + mMoveSpeed, 0.5f);
        }
    }

    private Tweener _cameraTweener;
    public void MoveCamera(bool isClose)
    {
        _cameraTweener?.Kill();
        if (isClose)
        {
            _cameraTweener = mCamera.transform.DOMoveZ(mCamera.transform.position.z - mScaleSpeed, 0.5f);
        }
        else
        {
            _cameraTweener = mCamera.transform.DOMoveZ(mCamera.transform.position.z + mScaleSpeed, 0.5f);
        }
    }

    public void ResetViews()
    {
        
        KillTweener();
        _cameraTweener = mCamera.transform.DOMove(mCameraPos, 0.5f);
        _moveTweener = transform.DOMove(mSelfPos, 0.5f);
        _rotateTweener = transform.DOLocalRotate(mSlefRo, 0.5f, RotateMode.FastBeyond360);
        
    }

    private void KillTweener()
    {
        _cameraTweener?.Kill();
        _moveTweener?.Kill();
        _rotateTweener?.Kill();
    }
    
}
