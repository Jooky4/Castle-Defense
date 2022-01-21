
// ����� ������ ����� �� ����������
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �������� ����
/// </summary>
public class EnemyController : MonoBehaviour
{
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

    [Header("������� ��������� ����")]
    public int percentChoiceBot = 10;

    [HideInInspector]
    public Vector3 lastPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        navMeshAgent.speed = speedBegin;
    }


    void Update()
    {
        UpdateMove();
    }

    void UpdateMove()
    {
        if (GameController.Instance.stateGame == StateGame.Game && navMeshAgent.speed > 0)
        {
            RunEnemy();
        }
        else
        {
            IdleEnemy();
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
            //if (navMeshAgent.speed == speedBegin)
            //{
            animator.SetBool("Run", true);
            // }
        }
    }

    /// <summary>
    /// ���� ���
    /// </summary>
   public void IdleEnemy()
    {
        navMeshAgent.speed = 0;
        if (animator) animator.SetBool("Run", false);
    }

    void UpdateTarget()
    {

    }

}

