using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBullet : MonoBehaviour
{

    GameObject _WorldGams = null;

    float _fBulletSpeed = 0.0f;

    void Start()
    {
        _WorldGams = GameObject.Find("World");
        _fBulletSpeed = 5.0f;
        StartCoroutine(ChangeParent());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _fBulletSpeed * Time.deltaTime);
    }

    IEnumerator ChangeParent()
    {
        yield return new WaitForSeconds(0.01f);
        transform.parent = _WorldGams.transform;
    }

}
