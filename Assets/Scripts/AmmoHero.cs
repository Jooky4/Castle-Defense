using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SHIT CODE  висит на боеприпасе игрока
public class AmmoHero : MonoBehaviour
{
    [Header("Массив снарядов на игроке")]
    [SerializeField]
    private Transform[] arrayAmmoBullets;

    [Header("Ссыль CheckerItem")]
    [SerializeField]
    private CheckerItem checkerItem;

    private int currentCountBulletAmmo;  // текущее колво снарядов на игроке
    private int lastCountBulletAmmo;     // предыдущее колво снарядов на игроке 


    void Start()
    {
        foreach (Transform ammoBullets in arrayAmmoBullets)
        {
            ammoBullets.gameObject.SetActive(false);   // выкл снаряды боезапаса
        }
    }

    void Update()
    {
        currentCountBulletAmmo = checkerItem.countItem;

        if (lastCountBulletAmmo != currentCountBulletAmmo)       // если изменились значения
        {
            UpdateVisuallPyramidBullets();
        }

        lastCountBulletAmmo = currentCountBulletAmmo;              // сохраняем значение
    }


    /// <summary>
    /// Обнавляем Визуал боезапаса
    /// </summary>
    void UpdateVisuallPyramidBullets()
    {
        for (int index = 0; index < arrayAmmoBullets.Length; index++)
        {
            bool temp = index < currentCountBulletAmmo;    // какое колво показывать 

            arrayAmmoBullets[index].gameObject.SetActive(temp);
        }
    }
}
