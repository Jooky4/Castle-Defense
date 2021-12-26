using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfPlayer
{
    none,
    Player,
    Enemy
}

/// <summary>
/// Весит на игроке. Соберает предметы
/// </summary>
public class CheckerItem : MonoBehaviour
{
    public int countItem;

    //[SerializeField]
    private int maxCountItem = 100;

    [HideInInspector]
    public bool isAddAir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet.isActive)
            {
                AddItem(other);
                bullet.isActive = false;
            }
        }
    }

    void AddItem(Collider other)
    {
        countItem++;
        countItem = Mathf.Clamp(countItem, 0, maxCountItem);
        Debug.Log(" Add bullet ");

    }

    public bool DelAir(int countAirDel)
    {
        bool result = false;

        result = true;

        countItem--;
        return result;
    }

}
