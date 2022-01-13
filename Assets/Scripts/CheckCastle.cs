
// ����� ������ ����� �� ��� ������� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ �������� �����, ����, �������� ����� �����, ��� ��������
/// </summary>
public class CheckCastle : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ������ �� �������� 

    [SerializeField]
    [Header("����� �� ������ ����������")]
    private Transform visualEnemy;

    [SerializeField]
    [Header("������� ������")]
    private ParticleSystem particleSys;

    [Header("����� ��������")]
    [SerializeField]
    private float timeAnimDead = 1;

    [Header("����� ��������� ���������")]
    [SerializeField]
    private float timeParticleSystem = 1;

    private Animator animator;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
    }


    /// <summary>
    /// ������ ����� �����
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
    /// �������� ������
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
    /// �������� � 
    /// ���� �������
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
    /// ���� �������
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
