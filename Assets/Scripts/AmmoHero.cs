using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SHIT CODE  ����� �� ���������� ������
public class AmmoHero : MonoBehaviour
{
    [Header("������ �������� �� ������")]
    [SerializeField]
    private Transform[] arrayAmmoBullets;

    [Header("����� CheckerItem")]
    [SerializeField]
    private CheckerItem checkerItem;

    private int currentCountBulletAmmo;  // ������� ����� �������� �� ������
    private int lastCountBulletAmmo;     // ���������� ����� �������� �� ������ 


    void Start()
    {
        foreach (Transform ammoBullets in arrayAmmoBullets)
        {
            ammoBullets.gameObject.SetActive(false);   // ���� ������� ���������
        }
    }

    void Update()
    {
        currentCountBulletAmmo = checkerItem.countItem;

        if (lastCountBulletAmmo != currentCountBulletAmmo)       // ���� ���������� ��������
        {
            UpdateVisuallPyramidBullets();
        }

        lastCountBulletAmmo = currentCountBulletAmmo;              // ��������� ��������
    }


    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    void UpdateVisuallPyramidBullets()
    {
        for (int index = 0; index < arrayAmmoBullets.Length; index++)
        {
            bool temp = index < currentCountBulletAmmo;    // ����� ����� ���������� 

            arrayAmmoBullets[index].gameObject.SetActive(temp);
        }
    }
}
