using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    EnemyState m_State;

    public float findDistance = 8f;

    Transform player;

    public float attackDistance = 2f;

    public float moveSpeed = 5f;

    CharacterController cc;

    void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

    }

    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
          //case EnemyState.Attack:
          //    Attack();
          //    break;
          //case EnemyState.Return:
          //    Return();
          //    break;
          //case EnemyState.Damaged:
          //    Damaged();
          //    break;
          //case EnemyState.Die:
          //    Die();
                //    break;
        }
    }

    void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            print("상태 전환: Idle -> Move");
        }
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;

            cc.Move(dir * moveSpeed * Time.deltaTime);


        }
        else
        {
            m_State = EnemyState.Attack;
            print("상태 전환: Move -> Attack");
        }
    }
    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {

        }
        else
        {

        }
    }
}
