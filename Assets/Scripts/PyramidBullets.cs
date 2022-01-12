using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ГАВНА скрипт висит на пирамиде с снарядами
/// </summary>
public class PyramidBullets : MonoBehaviour
{
    [Header("Массив пирамиды снарядов")]
    [SerializeField]
    private Transform[] arrayPyramidBullets;

    [Header("Ссыль PlatformGun")]
    [SerializeField]
    private PlatformGun platformGun;

    private int currentCountBulletGun;  // текущее колво снарядов на платформе 
    private int lastCountBulletGun;     // предыдущее колво снарядов на платформе 


    void Start()
    {
        foreach (Transform piramidBullets in arrayPyramidBullets)
        {
            piramidBullets.gameObject.SetActive(false);   // выкл снаряды на платформе
        }
    }

    void Update()
    {
        currentCountBulletGun = platformGun.countBulletGun;

        if (lastCountBulletGun != currentCountBulletGun)          // если изменились значения
        {
            UpdateVisuallPyramidBullets();
        }

        lastCountBulletGun = currentCountBulletGun;    // сохраняем значение
    }


    /// <summary>
    /// Обнавляем Визуал пирамиды
    /// </summary>
    void UpdateVisuallPyramidBullets()
    {
        for (int index = 0; index < arrayPyramidBullets.Length; index++)
        {
            bool temp = index < currentCountBulletGun;    // какое колво показывать 

            arrayPyramidBullets[index].gameObject.SetActive(temp);
        }
    }
}
