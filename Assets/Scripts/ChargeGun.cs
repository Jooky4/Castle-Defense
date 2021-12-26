
// ������ ����� �� ��������� � ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������� �����
/// </summary>
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

        if (checkerItem)  // ���� ��� ����� 
        {
            ChargingGun(); //�������� � ���� �������
        }
    }


    /// <summary>
    /// ������� �����
    /// </summary>
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
