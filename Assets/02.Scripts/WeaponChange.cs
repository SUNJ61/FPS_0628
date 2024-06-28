using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public SkinnedMeshRenderer spas12;
    public MeshRenderer[] Ak47; //ak�� m4�� �޽������� �ټ��̹Ƿ� �迭 ����
    public MeshRenderer[] M4A1;
    public Animation ComBatSg;

    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) //Alpha1 = Ű���� ���� ���� 1�̴�.
        {
            WeaponChage_ak();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponChage_m4();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponChage_Shotgun();
        }
    }

    private void WeaponChage_Shotgun()
    {
        ComBatSg.Play("draw");
        foreach(MeshRenderer AK in Ak47)
            AK.enabled = false;
        foreach(MeshRenderer M4 in M4A1)
            M4.enabled = false;
        spas12.enabled = true;
    }

    private void WeaponChage_m4()
    {
        ComBatSg.Play("draw");
        foreach (MeshRenderer AK in Ak47)
            AK.enabled = false;
        foreach (MeshRenderer M4 in M4A1)
            M4.enabled = true;
        spas12.enabled = false;
    }

    private void WeaponChage_ak()
    {
        ComBatSg.Play("draw");
        foreach (MeshRenderer AK in Ak47) // ak�� �Ž��� Ȱ��ȭ ��Ų��.
            AK.enabled = true; ; //������ AK47�� �Ž������� ������ ������ ����Ǿ� �����ϸ� �Ž� ��Ʈ��.
        foreach (MeshRenderer M4 in M4A1) // m4�� �Ž��� ��Ȱ��ȭ ��Ų��.
            M4.enabled = false;
        spas12.enabled = false; //������ �Ž��� ��Ȱ��ȭ ��Ų��.
    }
}
