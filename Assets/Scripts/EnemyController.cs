
// ������ ����� �� ����������
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �������� ����
/// </summary>
public class EnemyController : MonoBehaviour
{
    //enum ModeBot
    //{
    //    MinDist,
    //    Random,
    //    FollowPlayer
    //}

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    //[HideInInspector]
    public Transform currentTarget;   // ������� ����

    [Header("��������")]
    [SerializeField]
    private Animator animator;

    [Header("��������� �������� �����������")]
    [SerializeField]
    private float speedBegin = 3.0f;

    [HideInInspector]
    public Vector3 lastPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
        //RunEnemy();
    }


    void Update()
    {
        // if (GameController.Instance.isPlayGame)
        // {
        //  ActiveHardRun(multiplySpeed);
        //ActiveEaseRun();
         UpdateMove();
        //UpdateInflating();
        //  }

    }

    void UpdateMove()
    {
        if (GameController.Instance.stateGame != StateGame.Game)
        {
            IdleEnemy();
        }
        else
        {
            RunEnemy();
        }
    }

    /// <summary>
    /// ������� ���
    /// </summary>
    void RunEnemy()
    {
        navMeshAgent.destination = currentTarget.position;

        if (animator)
        {
            if (navMeshAgent.speed == speedBegin)
            {
                animator.SetBool("Run", true);
            }
        }
    }

    /// <summary>
    /// ���� ���
    /// </summary>
    void IdleEnemy()
    {
        navMeshAgent.speed = 0;
        if (animator) animator.SetBool("Run", false);
    }

    void UpdateTarget()
    {

    }

}

