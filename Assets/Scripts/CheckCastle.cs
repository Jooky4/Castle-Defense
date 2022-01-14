
// говно скрипт висит на доч обьекте бота
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// чекает колайдер замка, выкл, отнимает жизни замка, вкл анимацию
/// </summary>
public class CheckCastle : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ссылка на родителя 

    [SerializeField]
    [Header("Ссыль на визуал противника")]
    private Transform visualEnemy;

    [SerializeField]
    [Header("Система частиц")]
    private ParticleSystem particleSys;

    [Header("Время анимации")]
    [SerializeField]
    private float timeAnimDead = 1;

    [Header("Время проигрыша партиклов")]
    [SerializeField]
    private float timeParticleSystem = 1;

    private Animator animator;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
    }


    /// <summary>
    /// чекаем стену замка
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        FloorTower floorTower = other.GetComponent<FloorTower>();

        if (floorTower)
        {
            Boom();
        }
    }

    /// <summary>
    /// анимация взрыва
    /// </summary>
    void Boom()
    {
        if (animator)
        {
            animator.SetTrigger("Boom");
        }

       StartCoroutine(StartParticleSystem());
    }

    /// <summary>
    /// Партиклы и 
    /// выкл визуала
    /// </summary>
    /// <returns></returns>
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
    /// выкл обьекта
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeParticleSystem);
        Debug.Log("Kamikaze");
        GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }

}
