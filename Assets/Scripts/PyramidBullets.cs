using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����� ������ ����� �� �������� � ���������
/// </summary>
public class PyramidBullets : MonoBehaviour
{
    [Header("������ �������� ��������")]
    [SerializeField]
    private Transform[] arrayPyramidBullets;

    [Header("����� PlatformGun")]
    [SerializeField]
    private PlatformGun platformGun;

    private int currentCountBulletGun;  // ������� ����� �������� �� ��������� 
    private int lastCountBulletGun;     // ���������� ����� �������� �� ��������� 


    void Start()
    {
        foreach (Transform piramidBullets in arrayPyramidBullets)
        {
            piramidBullets.gameObject.SetActive(false);   // ���� ������� �� ���������
        }
    }

    void Update()
    {
        currentCountBulletGun = platformGun.countBulletGun;

        if (lastCountBulletGun != currentCountBulletGun)          // ���� ���������� ��������
        {
            UpdateVisuallPyramidBullets();
        }

        lastCountBulletGun = currentCountBulletGun;    // ��������� ��������
    }


    /// <summary>
    /// ��������� ������ ��������
    /// </summary>
    void UpdateVisuallPyramidBullets()
    {
        for (int index = 0; index < arrayPyramidBullets.Length; index++)
        {
            bool temp = index < currentCountBulletGun;    // ����� ����� ���������� 

            arrayPyramidBullets[index].gameObject.SetActive(temp);
        }
    }
}
