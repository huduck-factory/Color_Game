using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum E_COLOR
{
    E_RED = 0,
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

    public HPlayer Htscrp = null;

    void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}