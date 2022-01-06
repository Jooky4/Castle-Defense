
// ������ ����� �� FloorTower\CheckWall

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ ����������� � �������� ����� �����
/// </summary>
public class FloorTower : MonoBehaviour
{
    

    public int currentHealthCastle;

    private void Start()
    {
        currentHealthCastle = GameController.Instance.maxHealthCastle;
        GameController.Instance.currentHealthCastle = currentHealthCastle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CheckCastle>())
        {
            currentHealthCastle--;

            currentHealthCastle = Mathf.Clamp(currentHealthCastle, 0, GameController.Instance.maxHealthCastle);

            GameController.Instance.currentHealthCastle = currentHealthCastle;
        }
    }
}


