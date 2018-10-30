using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_GAMEMODE      // 게임모드와 디버그 모드를 정해서 총알 갯수 정함
{
    E_DEBUG = 0,
    E_GAME
}

enum E_COLOR                // 총알 색 정하기
{
    E_VOID = 0,
    E_RED,
    E_GREEN,
    E_BLUE
}

public class SGameMng : MonoBehaviour
{
    private static SGameMng _Instance = null;

    public static SGameMng I
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    // UI
    public bool bPause = false;     // 일시정지
    public int nWidth = 0;          // 해상도 가로
    public int nHeight = 0;         // 해상도 세로

    public E_GAMEMODE mode;         // 총알 타입설정
    public HPlayer Htscrp = null;   // 히어로 스크립트
    public int nBulletCount = 0;    // 총알 갯

    void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}