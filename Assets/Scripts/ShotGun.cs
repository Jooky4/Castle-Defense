//����� ������ ����� �� ��������� � ������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �������� �� �����
/// </summary>
public class ShotGun : MonoBehaviour
{
    [SerializeField]
    [Header("����� ����� ����������")]
    private float timeShoot = 1.0f;

    [SerializeField]
    [Header("�������� ���������� �������� �� ������� �������")]
    private float percentMultiPlay = 0.25f;

    //[SerializeField]
    private float currentPercentMultiPlay;

    [SerializeField]
    [Header("������� ������")]
    private ParticleSystem particleSys;

    private PlatformGun platformGun;

    public bool isFire = false;

    private int indexPoolBulletGun;

    //[SerializeField]
    private float percentCurrent;

    private void Start()
    {
        platformGun = GetComponent<PlatformGun>();
        StartCoroutine(ShotingGun());             // ������ ��������
    }

    /// <summary>
    /// �������� �� �����
    /// </summary>
    /// <returns></returns>
    IEnumerator ShotingGun()
    {
        float currentTimeShoot;


        //while (GameController.Instance.stateGame == StateGame.Game)
        while (true)
        {
            currentPercentMultiPlay = percentMultiPlay * GameController.Instance.upgradeDobleShootLevel;  // ������ �������� �������� ��������

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
                    platformGun.poolBulletGun[indexPoolBulletGun].GetComponent<BulletGun>().isFire = true;   // ����� ������ �� ���� �������� 

                    if (particleSys)
                    {
                        particleSys.Play();
                    }

                    indexPoolBulletGun++;      // ����������� ������ �������

                    if (indexPoolBulletGun < platformGun.poolBulletGun.Length)
                    {

                    }
                    else
                    {
                        indexPoolBulletGun = 0;    // ����� ������ ������������
                    }

                    platformGun.countBulletGun--;

                    Debug.Log(" SHOTGUN ");
                }
            }
            yield return new WaitForSeconds(currentTimeShoot);    // ���� 
        }
    }
}
