using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGun : MonoBehaviour
{

    public GameObject _BulletPrefab = null;

    float _fDelay = 0.0f;                       // 총알딜레이

    public int _nBulletType = 0;                //총알의 색깔을 알아오는 변수 일단 빨강만 설정해놓음  1:빨강 2:초록 3:파랑

    bool _bBulletShot = false;
    bool _bBulletAccept = false;
    bool _bReload = false;

    void Start()
    {
        if (SGameMng.I.mode.Equals(E_GAMEMODE.E_DEBUG)) { SGameMng.I.nBulletCount = 10; }
        else { SGameMng.I.nBulletCount = 10; }
        _nBulletType = (int)E_COLOR.E_RED;
        _fDelay = 1.0f;
    }

    void Update()
    {
        DelayCount();
        BulletShot();            //마우스 클릭시 함수가 불러오는데 이 함수에서 총알 색바꾸는 코드가 있어서 마우스 누르는 동시에 번호를 눌러야함
    }

    void BulletShot()
    {
        if (SGameMng.I.nBulletCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_bReload)
                {
                    if (!_bBulletAccept)
                    {
                        //_nBulletType = 1;         //빨강
                        SGameMng.I.nBulletCount--;
                        Instantiate(_BulletPrefab, transform.position, SGameMng.I.Htscrp.cam.transform.rotation);       // 카메라 방향으로 회전설정
                        _bBulletAccept = true;
                    }
                }
            }
        }
        else
        {
            Debug.Log("총알 부족");
            _bReload = true;
            StartCoroutine(BulletReload());
        }

        if (SGameMng.I.nBulletCount < 10)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _bReload = true;
                StartCoroutine(BulletReload());
            }
        }

        // ---- 나중에 지울코드
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Red");
            _nBulletType = (int)E_COLOR.E_RED;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Green");
            _nBulletType = (int)E_COLOR.E_GREEN;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Blue");
            _nBulletType = (int)E_COLOR.E_BLUE;
        }
        // ----
    }

    void DelayCount()
    {
        if (_bBulletAccept && !_bBulletShot)
        {
            _fDelay = Time.time;
            _bBulletShot = true;
        }
        if (Time.time > _fDelay + 0.5f)     //연사속도
        {
            _bBulletAccept = false;
            _bBulletShot = false;
        }
    }

    IEnumerator BulletReload()
    {
        yield return new WaitForSeconds(1.5f);
        _bReload = false;
        SGameMng.I.nBulletCount = 10;
    }

}
