
// скрипт висит на FloorTower\CheckWall

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// чекает противников и отнимает жизни замка
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


