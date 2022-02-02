//ГАВНА скрипт висит на платформе с пушкой
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// стрельба из пушки
/// </summary>
public class ShotGun : MonoBehaviour
{
    [SerializeField]
    [Header("Время между выстрелами")]
    private float timeShoot = 1.0f;

    [SerializeField]
    [Header("Значение увеличения процента на двойной выстрел")]
    private float percentMultiPlay = 0.25f;

    //[SerializeField]
    private float currentPercentMultiPlay;

    [SerializeField]
    [Header("Система частиц")]
    private ParticleSystem particleSys;

    private PlatformGun platformGun;

    public bool isFire = false;

    private int indexPoolBulletGun;

    //[SerializeField]
    private float percentCurrent;

    private void Start()
    {
        platformGun = GetComponent<PlatformGun>();
        StartCoroutine(ShotingGun());             // запуск стрельбы
    }

    /// <summary>
    /// стрельба из пушки
    /// </summary>
    /// <returns></returns>
    IEnumerator ShotingGun()
    {
        float currentTimeShoot;


        //while (GameController.Instance.stateGame == StateGame.Game)
        while (true)
        {
            currentPercentMultiPlay = percentMultiPlay * GameController.Instance.upgradeDobleShootLevel;  // расчет процента двойного выстрела

            percentCurrent = Random.Range(0.0f, 100.0f);

            if (percentCurrent <= currentPercentMultiPlay)
            {
                currentTimeShoot = 0.1f;
            }
            else
            {
                currentTimeShoot = timeShoot;
            }

            if (GameController.Instance.stateGame == StateGame.Game)
            {
                int countBulletgun = platformGun.countBulletGun;

                if (countBulletgun > 0)
                {
                    platformGun.poolBulletGun[indexPoolBulletGun].GetComponent<BulletGun>().isFire = true;   // берем снаряд из пула стреляем 

                    if (particleSys)
                    {
                        particleSys.Play();
                    }

                    indexPoolBulletGun++;      // увеличиваем индекс массива

                    if (indexPoolBulletGun < platformGun.poolBulletGun.Length)
                    {

                    }
                    else
                    {
                        indexPoolBulletGun = 0;    // чтобы небыло переполнения
                    }

                    platformGun.countBulletGun--;

                    Debug.Log(" SHOTGUN ");
                }
            }
            yield return new WaitForSeconds(currentTimeShoot);    // ждем 
        }
    }
}
