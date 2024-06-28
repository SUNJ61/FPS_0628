using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    /*
    1. ĵ���� UI�� ī�޶� �Ĵٺ���.
    */
    public Transform mainCam;
    public Transform tr;

    void Start()
    {
        mainCam = Camera.main.transform; //maincamera �±׸� ���� ī�޶� ã�� ��ġ���� �ش�.
        tr = GetComponent<Transform>(); //�ڱ��ڽ��� ��ġ���� ǥ��
    }

    void Update()
    {
        tr.LookAt(mainCam); //ĵ������ ����ķ�� �ٶ󺻴�.
    }
}
