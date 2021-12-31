
// скрипт висит на доч обьекте бота
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

    private Animator animator;

    [Header("¬рем€ анимации")]
    [SerializeField]
    private float timeAnimDead;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletGun>())
        {
            Dead();
        }
    }

    void Dead()
    {
        if (animator)
        {
            animator.SetBool("Dead",true);
        }
        StartCoroutine(DeActived());

    }

    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeAnimDead);
        Debug.Log("DeActived");
        GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }

}
