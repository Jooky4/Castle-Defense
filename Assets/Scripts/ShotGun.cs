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
    [Header("������� ������")]
    private ParticleSystem particleSys;

    private PlatformGun platformGun;

    public bool isFire = false;

    private int indexPoolBulletGun;

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
        //while (GameController.Instance.stateGame == StateGame.Game)
        while (true)
        {
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
            yield return new WaitForSeconds(timeShoot);    // ���� 
        }
    }
}
