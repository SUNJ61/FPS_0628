using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [Header("���۳�Ʈ��")]
    public GameObject bulletPrefab; //�Ѿ� ������Ʈ ��������
    public Transform firePos; // �߻� ��ġ ����
    public Animation fireAni; // �Ѿ� �߻� �Ҷ� �ִϸ��̼�
    public AudioSource fireSource; // �Ѿ� �߻� �Ҹ� ��� ��ġ
    public AudioClip fireClip; //�Ѿ� �߻� �Ҹ�
    public ParticleSystem muzzleFlash; // ����Ʈ ����

    [Header("���� ������")]
    public float fireTime;
    public HandCtrl handCtrl;
    public int bulletCount = 0;
    bool isReload = false;

    void Start()
    {
        //���� �� ��ũ��Ʈ�� �ִ� gameObject(������Ʈ)�� �����ϴ� ���۳�Ʈ HandCtrl�� handCtrl�� ����
        handCtrl = this.gameObject.GetComponent<HandCtrl>();
        fireTime = Time.time; // ����ð��� ����
        muzzleFlash.Stop();
    }

  
    void Update()
    {
        #region �ܹ�
        //0 ���콺 ���� ��ư ������ �� / 1 ���콺 ������ ��ư / 2 ���콺 ��
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Fire();
        //}
        #endregion
        #region ����
            if (Input.GetMouseButton(0)) //������ ���� ��� ȣ��ȴ�. �����̰� ������ ������Ʈ�� ������.
            {
                if (Time.time - fireTime > 0.2f) // ����ð����� ���� �ð��� �� �ð��� 0.1���� Ŭ ���
                {//��, �� ������ 0.1���� �����̸� �ִ� ȿ���� �ִ�.
                    if (!handCtrl.isRun && !isReload)       
                            Fire();
                    fireTime = Time.time;
                }
            }
        #endregion
        //if(Input.GetMouseButtonUp(0)) //���콺 ���� ��ư�� ����� �� �ߵ�
        //{
        //    muzzleFlash.Stop(); //Fire�Լ��� �ѱ�ȭ���� ���ִ� ����� �־ �ʿ������.
        //}
    }
    void Fire()
    {
        ++bulletCount;
        //          ������        ���            ��� ȸ���ϴ���
        Instantiate(bulletPrefab, firePos.position, firePos.rotation); //������Ʈ ���� �Լ�.
        fireSource.PlayOneShot(fireClip, 1.0f);
        fireAni.Play("fire");
        muzzleFlash.Play();
        Invoke("MuzzleFlashDisable", 0.03f);
        //       "�ż��� ��"         �ð�   => ���ϴ� �ð����� ��ŭ �ż��带 ȣ�� (0.03�ʸ��� ȣ��)

        if(bulletCount == 10)
        {
            StartCoroutine(Reload()); //������ �����ڰ� ���ϴ� �������� ������� �� �� ���
            // �Ʒ� IEnumerator Reload()�� ȣ���Ѵ�.
        }
    }
    IEnumerator Reload()
    {
        isReload = true;
        fireAni.Play("pump3"); //���ε� �ִϸ��̼� ���
        yield return new WaitForSeconds(0.8f); //0.5�� �Ŀ� ���� ��ȯ ������ �ѱ��. (0.5���� ���� �ڵ����)
        bulletCount = 0;
        isReload = false;
    }
    void MuzzleFlashDisable()
    {
        muzzleFlash.Stop();
    }
}

