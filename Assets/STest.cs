using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STest : MonoBehaviour 
{
    public Camera cam;
    private Rigidbody rig;
    [SerializeField]private float fMouseRotate = 10.0f;
    [SerializeField]private float fSpeed = 10f;

    void Start () 
    {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovePlayer();
    }

    private void LateUpdate()
    {
        //회전하고 싶은 축과 입력축이 반대인 것에 유의
        float yRot = Input.GetAxis("Mouse X") * fMouseRotate;
        float xRot = Input.GetAxis("Mouse Y") * fMouseRotate;

        //오브젝트(기준이 되는 축을 유지해야 됨)와 카메라 회전을 분리해야 됨
        //쿼터니안은 곱해야 누적됨
        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);//부호 주의
    }

    void MovePlayer()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 PVector = new Vector3(hAxis, 0, vAxis) * fSpeed * Time.deltaTime;

        rig.MovePosition(transform.position + PVector);
    }
}
