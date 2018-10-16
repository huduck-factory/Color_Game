using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGun : MonoBehaviour
{

    public GameObject _BulletPrefab = null;

    float _fDelay = 0.0f;

    bool _bBulletShot = false;
    bool _bBulletAccept = false;

    // Use this for initialization
    void Start()
    {
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
                Debug.Log("발사");
                Instantiate(_BulletPrefab, transform.localPosition, Quaternion.identity);
                _bBulletAccept = true;
            }
        }
    }

    void DelayCount()
    {
        if (_bBulletAccept && !_bBulletShot)
        {
            _fDelay = Time.time;
            _bBulletShot = true;
        }
        if (Time.time > _fDelay + 3f)                                //연사속도
        {
            _bBulletAccept = false;
            _bBulletShot = false;
        }
    }
}
