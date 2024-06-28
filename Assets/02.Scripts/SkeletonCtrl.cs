using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Utility;

public class SkeletonCtrl : MonoBehaviour
{
    [Header("컴포넌트")]
    public Transform Skel;
    public Transform Player;
    public NavMeshAgent nav;
    public Animator animator;
    public SkeletonDamage Skel_D;

    [Header("사용 변수")]
    public string player = "Player";
    public string At = "isAttack";
    public string Tr = "isTrace";
    public float AttackDis = 3.0f;
    public float TraceDis = 20.0f;

    void Start()
    {
        Skel = gameObject.GetComponent<Transform>();
        Player = GameObject.FindWithTag(player).GetComponent<Transform>();
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Skel_D = GetComponent<SkeletonDamage>();
    }


    void Update()
    {
        if (Skel_D.isDie) return;

        float Dist = Vector3.Distance(Player.position, Skel.position);
        SkelCtrl(Dist);
    }

    private void SkelCtrl(float Dist)
    {
        if (Dist <= AttackDis)
        {
            nav.isStopped = true;
            animator.SetBool(At, true);
        }
        else if (Dist <= TraceDis)
        {
            nav.isStopped = false;
            animator.SetBool(At, false);
            animator.SetBool(Tr, true);
            nav.destination = Player.position;
        }
        else if (Dist > TraceDis)
        {
            nav.isStopped = true;
            animator.SetBool(At, false);
            animator.SetBool(Tr, false);
        }
    }
}
