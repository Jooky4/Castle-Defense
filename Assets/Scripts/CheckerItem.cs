
//скрипт Весит на игроке.
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
///  Соберает предметы
/// </summary>
public class CheckerItem : MonoBehaviour
{
    public int countItem;

    //[SerializeField]
    private int maxCountItem = 100;

    [HideInInspector]
    public bool isAddAir;


    /// <summary>
    /// если это предмет bullet то собираем
    /// </summary>
    /// <param name="other"></param>
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


    /// <summary>
    /// добавление кол ва предметов игроку
    /// </summary>
    /// <param name="other"></param>
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
