using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTower : MonoBehaviour
{
    [SerializeField]
    [Header("Мах число жизней")]
    private int maxHealthCastle = 10;

    public int currentHealthCastle;

    private void Start()
    {
        currentHealthCastle = maxHealthCastle;
        GameController.Instance.currentHealthCastle = currentHealthCastle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CheckCastle>())
        {
            currentHealthCastle--;

            currentHealthCastle = Mathf.Clamp(currentHealthCastle, 0, maxHealthCastle);

            GameController.Instance.currentHealthCastle = currentHealthCastle;
        }
    }
}


