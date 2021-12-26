
// скрипт висит на доч обьекте бота
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// чекаем попадание сн€р€да
/// </summary>
public class CheckBullet : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ссылка на родител€ 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletGun>())
        {
            Debug.Log("DeActive");
            parentObject.gameObject.SetActive(false);
        }
    }
}
