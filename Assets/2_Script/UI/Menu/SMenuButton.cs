using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMenuButton : MonoBehaviour
{
    public void SetWidth(int nWidth)        // 가로설정(창 크기)
    {
        SGameMng.I.nWidth = nWidth;
    }

    public void SetHeight(int nHeight)      // 가로설정(창 크기)
    {
        SGameMng.I.nHeight = nHeight;
    }
    public void CountinueBtn()              // 일시정지해제
    {
        SGameMng.I.bPause = false;
    }
    public void ResetScreen()               // 해상도 제설정
    {
        Screen.SetResolution(SGameMng.I.nWidth, SGameMng.I.nHeight, false);
    }
}
