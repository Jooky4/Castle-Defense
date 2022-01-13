
//����� ������ ����� �� ������� �����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    // [HideInInspector]
    public bool isFire = false;

    public float speed = 1.0f;

    private Vector3 beginPositionBulletGun;

    [SerializeField]
    [Header("������� ������")]
    private ParticleSystem particleSys;

    void Start()
    {
        beginPositionBulletGun = gameObject.transform.position;   //���� ��� �������
    }

    void Update()
    {
        if (isFire)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);      // ����� � �����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletHit();
    }


    /// <summary>
    /// ��������� � ������
    /// </summary>
    void BulletHit()
    {
        isFire = false;

        gameObject.transform.position = beginPositionBulletGun;

        if (particleSys)
        {
            particleSys.Play();
        }
        Debug.Log(" Hit ");
    }

}
