using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] _ColorGams = null;

    public SpriteRenderer _BackgroundSr = null;

    Rigidbody _PlayerRig = null;

    public float _fPlayerSpeed = 0.0f;
    public float _fPlayerJumpPower = 0.0f;
    public float _fPlayerGravity = 0.0f;

    public int _nColorType = 0;

    public bool _bJumpAccept = true;

    // Use this for initialization
    void Start()
    {
        _PlayerRig = GetComponent<Rigidbody>();
        _fPlayerSpeed = 3.0f;
        _fPlayerJumpPower = 300.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        ColorMng();
        ColorChange();
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * _fPlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * _fPlayerSpeed * Time.deltaTime);
        }
        if (_bJumpAccept)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _bJumpAccept = false;
                _PlayerRig.AddForce(Vector3.up * _fPlayerJumpPower);
            }
        }
    }

    void ColorMng()
    {
        switch(_nColorType)
        {
            case 1:
                _BackgroundSr.color = new Color(0 / 255, 0 / 255, 255 / 255, 255 / 255);
                for (int i = 0; i < _ColorGams.Length; ++i)
                {
                    _ColorGams[i].SetActive(true);
                    if (i.Equals(0))
                    {
                        _ColorGams[i].SetActive(false);
                    }
                }
                break;

            case 2:
                _BackgroundSr.color = new Color(255 / 255, 0 / 255, 0 / 255, 255 / 255);
                for (int i = 0; i < _ColorGams.Length; ++i)
                {
                    _ColorGams[i].SetActive(true);
                    if (i.Equals(1))
                    {
                        _ColorGams[i].SetActive(false);
                    }
                }
                break;

            case 3:
                _BackgroundSr.color = new Color(0 / 255, 255 / 255, 0 / 255, 255 / 255);
                for (int i = 0; i < _ColorGams.Length; ++i)
                {
                    _ColorGams[i].SetActive(true);
                    if (i.Equals(2))
                    {
                        _ColorGams[i].SetActive(false);
                    }
                }
                break;

            case 4:
                _BackgroundSr.color = new Color(255 / 255, 255 / 255, 0 / 255, 255 / 255);
                for (int i = 0; i < _ColorGams.Length; ++i)
                {
                    _ColorGams[i].SetActive(true);
                    if (i.Equals(3))
                    {
                        _ColorGams[i].SetActive(false);
                    }
                }
                break;
        }
    }

    void ColorChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))               //blue
            _nColorType = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))               //red
            _nColorType = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))               //green
            _nColorType = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4))               //yellow
            _nColorType = 4;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Door"))
        {
            Debug.Log("클리어");
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            if (!_bJumpAccept)
                _bJumpAccept = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            _bJumpAccept = false;
        }
    }

}
