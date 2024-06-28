using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDamage : MonoBehaviour
{
    [Header("������Ʈ")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;
    public GameObject BLDEF;
    public FireCtrl fireCtrl; //�÷��̾� �߻���ġ�� �����´�.

    [Header("��� ����")]
    public string Player = "Player";
    public string Bt = "BULLET";
    public string hit_T = "hitTrigger";
    public string die_T = "dieTrigger";
    public bool isDie = false; 
    public int Mhp = 100;
    public int Inithp = 0;

    [Header("UI")]
    public Image hp_image;
    public Text hp_text;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        fireCtrl = GameObject.FindWithTag(Player).GetComponent<FireCtrl>(); // ���̶�Ű �ȿ� �÷��̾� �±׸� ã�� firectrlŬ������ ã�´�.

        hp_image.color = Color.green;
        Inithp = Mhp;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag(Player))
        {
            rb.mass = 800f;
            //rb.freezeRotation = true;
            rb.isKinematic = false;
        }
        else if(col.gameObject.CompareTag(Bt))
        {
            animator.SetTrigger(hit_T);
            HitInfo(col);
            Inithp -= col.gameObject.GetComponent<BulletCtrl>().damage;
            UI_Ctrl();

            if (Inithp <= 0)
            {
                Die_fc();
            }
        }
    }

    private void UI_Ctrl()
    {
        hp_image.fillAmount = (float)Inithp / (float)Mhp;
        hp_text.text = $"HP : <color=#ff0000>{Inithp.ToString()}</color>";
        if (Inithp < 30)
            hp_image.color = Color.red;
        else if (Inithp < 50)
            hp_image.color = Color.yellow;
    }

    private void Die_fc()
    {
        animator.SetTrigger(die_T);
        rb.isKinematic = true;
        capCol.enabled = false;
        isDie = true;
        Destroy(gameObject, 5.0f);
    }

    private void HitInfo(Collision col)
    {
        Destroy(col.gameObject);
        Vector3 hitpos = col.transform.position;
        Vector3 hitnormal = hitpos - fireCtrl.transform.position; // ������ġ - �߻� ��ġ (���� �Ÿ� �� ������ ��������.)
        hitnormal = hitnormal.normalized; //������ ������ �����. (���͸� ����)
        Quaternion rot = Quaternion.LookRotation(hitnormal); // ���͸� �Է� �޾� �׹������� ȸ����Ų��.

        GameObject Blood = Instantiate(BLDEF, hitpos,rot);
        Destroy(Blood, Random.Range(0.8f, 1.2f));
    }
}
