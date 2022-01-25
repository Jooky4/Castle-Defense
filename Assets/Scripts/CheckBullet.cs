
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

    [SerializeField]
    [Header("����� �� ������ ����������")]
    private Transform visualEnemy;

    private EnemyController enemyController;

    private Animator animator;

    [SerializeField]
    [Header("������� ������")]
    private ParticleSystem particleSys;

    [Header("����� ��������")]
    [SerializeField]
    private float timeAnimDead;

    [Header("����� ��������� ���������")]
    [SerializeField]
    private float timeParticleSystem = 0;

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

        GameController.Instance.currentMoney += enemyController.moneyForBot;
        GameController.Instance.countDeadBots++;

        if (animator)
        {
            animator.SetTrigger("Dead");
        }

        StartCoroutine(StartParticleSystem());
    }

    private IEnumerator StartParticleSystem()
    {
        yield return new WaitForSeconds(timeAnimDead);

        if (particleSys)
        {
            particleSys.Play();
        }

        visualEnemy.gameObject.SetActive(false);

        StartCoroutine(DeActived());
    }


    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeParticleSystem);
        Debug.Log("DeActived");
        GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }

}
