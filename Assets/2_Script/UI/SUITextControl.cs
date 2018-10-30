using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUITextControl : MonoBehaviour 
{

    [SerializeField]private Text bCountTest = null;     // 총알 갯수 텍스트

	void Start () 
    {
        bCountTest.text = SGameMng.I.nBulletCount.ToString();
   	}

    void Update()
    {
        bCountTest.text = SGameMng.I.nBulletCount.ToString();
    }

}
