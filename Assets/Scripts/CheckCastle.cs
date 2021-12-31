
// ������ ����� �� ��� ������� ����
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

    private Animator animator;

    [Header("����� ��������")]
    [SerializeField]
    private float timeAnimDead = 1;

    private void Start()
    {
        animator = parentObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FloorTower floorTower = other.GetComponent<FloorTower>();

        if (floorTower)
        {
            Dead();
        }
    }

    void Dead()
    {
        if (animator)
        {
            animator.SetBool("Dead", true);
        }
        StartCoroutine(DeActived());

    }

    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeAnimDead);
        Debug.Log("Kamikaze");
        GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }

}
