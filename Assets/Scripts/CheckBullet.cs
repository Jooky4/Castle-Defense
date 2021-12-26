
// ������ ����� �� ��� ������� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ ��������� �������
/// </summary>
public class CheckBullet : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ������ �� �������� 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletGun>())
        {
            Debug.Log("DeActive");
            parentObject.gameObject.SetActive(false);
        }
    }
}
