
//������ ����� �� ��������� ��� �����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Header("������ ����")]
    private Transform visualBullet;

    [SerializeField]
    [Header("������� ������")]
    private ParticleSystem particleSys;

    //[HideInInspector]
    public bool isActive = true;
    
    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveController>())        //���� ��� �����
        {
            visualBullet.gameObject.SetActive(false);   // ����
            Debug.Log(" Active false");
            if (particleSys)
            {
                particleSys.Play();
            }
        }
    }
}
