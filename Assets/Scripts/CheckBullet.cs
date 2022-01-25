
// говно скрипт висит на доч обьекте бота
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// чекаем попадание сняряда, выкл, вкл анимацию
/// </summary>
public class CheckBullet : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ссылка на родителя 

    [SerializeField]
    [Header("Ссыль на визуал противника")]
    private Transform visualEnemy;

    private EnemyController enemyController;

    private Animator animator;

    [SerializeField]
    [Header("Система частиц")]
    private ParticleSystem particleSys;

    [Header("Время анимации")]
    [SerializeField]
    private float timeAnimDead;

    [Header("Время проигрыша партиклов")]
    [SerializeField]
    private float timeParticleSystem = 0;

    [Header("Мах колво жизней бота")]
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
    /// чекаем пули
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
    /// анимация смерти
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
    /// выкл полностью обьект
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
