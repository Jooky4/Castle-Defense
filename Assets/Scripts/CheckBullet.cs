
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

    [Header("��� ����� ������ ����")]
    [SerializeField]
    private int maxHealthBot = 1;

    private int currentHealthBot;

    private void Start()
    {
        currentHealthBot = maxHealthBot;
        animator = parentObject.GetComponent<Animator>();
        enemyController = parentObject.GetComponent<EnemyController>();
    }

    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        BulletGun bulletGun;
        bulletGun = other.GetComponent<BulletGun>();

        if (bulletGun)
        {
            TakeDamage(bulletGun.damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealthBot -= damage;
        if (currentHealthBot < 1)
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
