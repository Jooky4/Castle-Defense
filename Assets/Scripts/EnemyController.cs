
// скрипт весит на противнике
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// ƒвижение бота
/// </summary>
public class EnemyController : MonoBehaviour
{
    enum ModeBot
    {
        MinDist,
        Random,
        FollowPlayer
    }

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform currentTarget;   // текуща€ цель

    //[SerializeField]
    private Animator animator;

    [Header("Ќачальна€ скорость перемещени€")]
    [SerializeField]
    private float speedBegin = 3.0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>() as NavMeshAgent;
        animator = GetComponentInChildren<Animator>();
        RunEnemy();
    }


    void Update()
    {
        // if (GameController.Instance.isPlayGame)
        // {
        //  ActiveHardRun(multiplySpeed);
        //ActiveEaseRun();
        // UpdateMove();
        //UpdateInflating();
        //  }

    }

    void UpdateMove()
    {

    }

    /// <summary>
    /// побежал бот
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
    /// стоп бот
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

