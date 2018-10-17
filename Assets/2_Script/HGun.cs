using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGun : MonoBehaviour
{

    public GameObject _BulletPrefab = null;

    float _fDelay = 0.0f;

    public int _nBulletType = 0;                               //총알의 색깔을 알아오는 변수 일단 빨강만 설정해놓음  1:빨강 2:초록 3:파랑

    bool _bBulletShot = false;
    bool _bBulletAccept = false;

    // Use this for initialization
    void Start()
    {
        _nBulletType = 1;
        _fDelay = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        DelayCount();
        BulletShot();
    }

    void BulletShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_bBulletAccept)
            {
                //Debug.Log("발사");
                //_nBulletType = 1;                   //빨강
                Instantiate(_BulletPrefab, transform.position, SGameMng.I.Htscrp.transform.rotation);
                _bBulletAccept = true;
            }
        }
        //////////////////////////////////////////////////나중에 지울 코드////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Red");
            _nBulletType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Green");
            _nBulletType = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Blue");
            _nBulletType = 3;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    void DelayCount()
    {
        if (_bBulletAccept && !_bBulletShot)
        {
            _fDelay = Time.time;
            _bBulletShot = true;
        }
        if (Time.time > _fDelay + 0.5f)                                //연사속도
        {
            _bBulletAccept = false;
            _bBulletShot = false;
        }
    }
}
