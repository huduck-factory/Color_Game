using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMenuButton : MonoBehaviour
{
    public void SetWidth(int nWidth)
    {
        SGameMng.I.nWidth = nWidth;
    }

    public void SetHeight(int nHeight)
    {
        SGameMng.I.nHeight = nHeight;
    }
    public void CountinueBtn()
    {
        SGameMng.I.bPause = false;
    }
    public void ResetScreen()
    {
        Screen.SetResolution(SGameMng.I.nWidth, SGameMng.I.nHeight, false);
    }
}
