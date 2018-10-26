using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUITextControl : MonoBehaviour 
{

    [SerializeField]private Text bCountTest = null;
	// Use this for initialization
	void Start () 
    {
        bCountTest.text = SGameMng.I.nBulletCount.ToString();
   	}

    void Update()
    {
        bCountTest.text = SGameMng.I.nBulletCount.ToString();
    }

}
