using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField]
    [Header("Время между выстрелами")]
    private float timeShoot = 1.0f;

    private PlatformGun platformGun;

    public bool isFire = false;

    private int indexPoolBulletGun;

    private void Start()
    {
        platformGun = GetComponent<PlatformGun>();
        InvokeRepeating("ShotingGun", 0, timeShoot);
    }

    private void Update()
    {
        //    if (!isFire)
        //    {
        //        ShotingGun();
        //    }
    }

    void ShotingGun()
    {
        //Transform bulletGun = platformGun.bulletGun;

        int countBulletgun = platformGun.countBulletGun;

        if (countBulletgun > 0)
        {
            platformGun.poolBulletGun[indexPoolBulletGun].GetComponent<BulletGun>().isFire = true;

            indexPoolBulletGun++;

            if (indexPoolBulletGun < platformGun.poolBulletGun.Length)
            {

            }
            else
            {
                indexPoolBulletGun = 0;
            }

            platformGun.countBulletGun--;

            Debug.Log(" SHOTGUN ");
        }
    }


}
