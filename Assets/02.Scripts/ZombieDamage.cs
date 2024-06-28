using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDamage : MonoBehaviour
{
    [Header("���۳�Ʈ")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;
    public GameObject BloodEffect;
    public FireCtrl fireCtrl;

    [Header("��� ����")]
    public string playerTag = "Player"; //�̰��� "Player" ���ڿ��� �����Ҵ� �Ѱ��̴�.
    public string bulletTag = "BULLET";
    public string hitTrigger = "HitTrigger";
    public string dieTrigger = "DieTrigger";
    public int hitCount = 0;
    public bool isDie = false; // ���� �������� �� true�� ������Ʈ

    [Header("UI")]
    public Image hpBar;
    public Text hpTxt;
    public int maxHp = 100;
    public int HpInit = 0; //�ʱⰪ
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        fireCtrl = GameObject.FindWithTag(playerTag).GetComponent<FireCtrl>();

        HpInit = maxHp;
        hpBar.color = Color.green;
    }

    private void OnCollisionEnter(Collision col) //�浹�� ������ �� isTriggerüũ �������� ���
    {
        if(col.gameObject.CompareTag(playerTag)) //col.gameObject.CompareTag == "Player"�� �����Ҵ�� �񱳸� ���ÿ� ����, ��Ÿ�ӿ��� ������ ���� �޸�, �ӵ��� �پ��� ��鿡�� �Ҹ���.
        {//���� �Ҵ�� �񱳸� �����ϴ� �� ����� �� �ַ� ����.
            rb.mass = 800f; //�÷��̿� �浹�ϸ� ���԰� 5000���� �þ��. -> �÷��̾�� �浹�ϴ��� �ȹи����� ����
            rb.freezeRotation = true; //�΋H���� ȸ�� �����ϱ�.
            rb.isKinematic = false; //�΋H���� �������� �ְ� ���� (�ȹи����� ����)
        }
        else if(col.gameObject.CompareTag(bulletTag))
        {
            HitInfo(col);
            HpInit -= col.gameObject.GetComponent<BulletCtrl>().damage; //���� ������Ʈ �ȿ��ִ� �Ѿ� ��ũ��Ʈ�� ������ ������ �����´�.
            hpBar.fillAmount = (float)HpInit/(float)maxHp; //fillAmount�� �÷԰��� �޴´�.
            hpTxt.text = $"Hp : <color=#ff0000>{HpInit.ToString()}</color>";
            if (hpBar.fillAmount <= 0.3f)
                hpBar.color = Color.red;
            else if (hpBar.fillAmount <=0.5f)
                hpBar.color = Color.yellow;

            if (++hitCount == 5)
            {
                Zombie_Die();
            }
        }
    }

    private void HitInfo(Collision col)
    {
        //Print("�ƾ�");
        Destroy(col.gameObject); //�浹�� ������Ʈ ����
        animator.SetTrigger(hitTrigger);

        Vector3 hitpos = col.transform.position; // ���� ��ġ�� 3���� ������ ����
        Vector3 hitnormal = hitpos - fireCtrl.transform.position;
        hitnormal = hitnormal.normalized;
        Quaternion hitrot = Quaternion.LookRotation(hitnormal);
        //Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, hitpos.normalized); // ���� ���� ��ŭ ȸ���ϰ� �����ϴ� ��ɾ�, ���� ���⿡�� ���� �������� ȸ��
        var blood = Instantiate(BloodEffect, hitpos, hitrot);
        //������Ʈ ���� (�浹�� ������ ������Ʈ���� ȸ�� ����.), var = GameObject
        Destroy(blood, Random.Range(0.8f, 1.2f)); // 0.8~1.2�� ������ �ð� ���� ������ blood �ڷ��� ����
    }

    private void OnCollisionExit(Collision col)
    {
        rb.mass = 75f;
    }

    void Zombie_Die()
    {
        animator.SetTrigger(dieTrigger);
        capCol.enabled = false; //�ݶ��̴� ��Ȱ��ȭ
        rb.isKinematic = true; //������Ʈ�� �������� ������.
        isDie = true;
        Destroy(gameObject, 5.0f);
    }
}
