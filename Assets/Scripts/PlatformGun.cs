using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGun : MonoBehaviour
{
    [SerializeField]
    [Header("Ствол пушки")]
    //private GameObject gunPoint;
    private Transform gunPoint;

    //[HideInInspector]
    public int countBulletGun;

    [Header("Префаб снаряда пушки")]
    [SerializeField]
    private Transform prefabBulletGun;

    [HideInInspector]
    public Transform[] poolBulletGun;


    public int indexPoolBulletGun;

    private void Start()
    {
        InstantiateBulletGun();
    }

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
