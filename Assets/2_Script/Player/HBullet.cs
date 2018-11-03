using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBullet : MonoBehaviour
{
    HGun _GunSc = null;

    GameObject _WorldGams = null;

    Material _BulletMat = null;

    float _fBulletSpeed = 0.0f;

    [SerializeField] private Rigidbody rig = null;

    void Start()
    {
        _WorldGams = GameObject.Find("World");
        _GunSc = GameObject.Find("Gun").GetComponent<HGun>();
        _BulletMat = GetComponent<MeshRenderer>().material;
        _fBulletSpeed = 70.0f;
        BulletColorMng();
        transform.parent = _WorldGams.transform;
    }

    void Update()
    {
        rig.AddForce(transform.forward * _fBulletSpeed);    // 보고있는 방향으로 이동
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
            if (_GunSc._nBulletType.Equals((int)E_COLOR.E_RED))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.red;

            else if (_GunSc._nBulletType.Equals((int)E_COLOR.E_GREEN))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.green;

            else if (_GunSc._nBulletType.Equals((int)E_COLOR.E_BLUE))
                col.transform.GetComponent<MeshRenderer>().material.color = Color.blue;

            Destroy(gameObject);
        }
    }

}
