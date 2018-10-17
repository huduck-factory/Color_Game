﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBullet : MonoBehaviour
{
    HGun _GunSc = null;

    GameObject _WorldGams = null;

    Material _BulletMat = null;

    float _fBulletSpeed = 0.0f;

    void Start()
    {
        _WorldGams = GameObject.Find("World");
        _GunSc = GameObject.Find("Gun").GetComponent<HGun>();
        _BulletMat = GetComponent<MeshRenderer>().material;
        _fBulletSpeed = 5.0f;
        BulletColorMng();
        transform.parent = _WorldGams.transform;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _fBulletSpeed * Time.deltaTime);
    }

    void BulletColorMng()                              //총알 색 변환 함수
    {
        switch (_GunSc._nBulletType)                   //총알 색 추가 될 수 있으니 switch로 해놓음
        {
            case 1:
                _BulletMat.color = Color.red;
                break;
            case 2:
                _BulletMat.color = Color.green;
                break;
            case 3:
                _BulletMat.color = Color.blue;
                break;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag.Equals("Object"))
        {
            Debug.Log("충돌!");
            if (_GunSc._nBulletType.Equals(1))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.red;

            else if (_GunSc._nBulletType.Equals(2))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.green;

            else if (_GunSc._nBulletType.Equals(3))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.blue;

            Destroy(gameObject);
        }
    }

}
