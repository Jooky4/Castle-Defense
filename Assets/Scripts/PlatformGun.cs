
//ГАВНА скрипт висит на платформе с пушкой
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// основные хар-ки и создание пула снарядов
/// </summary>
public class PlatformGun : MonoBehaviour
{
    [SerializeField]
    [Header("Ствол пушки")]
    private Transform gunPoint;

    //[HideInInspector]
    public int countBulletGun;  

    [Header("Префаб снаряда пушки")]
    [SerializeField]
    private Transform prefabBulletGun;

    [HideInInspector]
    public Transform[] poolBulletGun;

    private void Start()
    {
        InstantiateBulletGun(); 
    }


    /// <summary>
    /// Пул снарядов пушки
    /// </summary>
    private void InstantiateBulletGun()
    {
        int volumeBulletGun = 10;
        poolBulletGun = new Transform[volumeBulletGun];

        for (int index = 0; index < poolBulletGun.Length; index++)
        {
            Vector3 positionBulletGun = new Vector3(gunPoint.position.x, gunPoint.position.y, gunPoint.position.z);
            poolBulletGun[index] = Instantiate(prefabBulletGun, positionBulletGun, Quaternion.identity);
        }
    }

}
