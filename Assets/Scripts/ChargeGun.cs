using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGun : MonoBehaviour
{
    private PlatformGun platformGun;

    private void Start()
    {
        platformGun = GetComponent<PlatformGun>();
    }

    private CheckerItem checkerItem;

    private void OnTriggerEnter(Collider collision)
    {
        checkerItem = collision.gameObject.GetComponent<CheckerItem>();

        if (checkerItem)
        {
            ChargingGun();
        }
    }

    private void ChargingGun()
    {
        if (checkerItem.countItem > 0)
        {
            platformGun.countBulletGun += checkerItem.countItem;
            checkerItem.countItem = 0;

            Debug.Log(" ChargingGun ");
        }
    }
}
