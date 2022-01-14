
// говно скрипт висит на доч обьекте бота
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// чекаем попадание сн€р€да, выкл, вкл анимацию
/// </summary>
public class CheckBullet : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ссылка на родител€ 

    private EnemyController enemyController;

    private Animator animator;

    [Header("¬рем€ анимации")]
    [SerializeField]
    private float timeAnimDead;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
        enemyController = parentObject.GetComponent<EnemyController>();
    }

    /// <summary>
    /// чекаем пули
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
    /// анимаци€ смерти
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
