
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

    private EnemyController enemyController;

    private Animator animator;

    [Header("Время анимации")]
    [SerializeField]
    private float timeAnimDead;

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
        if (animator)
        {
            animator.SetTrigger("Dead");
        }

        StartCoroutine(DeActived());

    }

    /// <summary>
    /// выкл полностью обьект
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
