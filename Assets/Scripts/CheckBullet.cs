
// ����� ������ ����� �� ��� ������� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ ��������� �������, ����, ��� ��������
/// </summary>
public class CheckBullet : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ������ �� �������� 

    private EnemyController enemyController;

    private Animator animator;

    [Header("����� ��������")]
    [SerializeField]
    private float timeAnimDead;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
        enemyController = parentObject.GetComponent<EnemyController>();
    }

    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletGun>())
        {
            Dead();
        }
    }


    /// <summary>
    /// �������� ������
    /// </summary>
    void Dead()
    {
        enemyController.IdleEnemy();
        if (animator)
        {
            animator.SetTrigger("Dead");
        }
        
        StartCoroutine(DeActived());

    }

    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeAnimDead);
        Debug.Log("DeActived");
        GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }

}
