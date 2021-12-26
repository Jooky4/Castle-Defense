
//скрипт висит на предметах для сбора
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Header("Визуал пули")]
    private Transform visualBullet;

    [SerializeField]
    [Header("Система частиц")]
    private ParticleSystem particleSys;

    //[HideInInspector]
    public bool isActive = true;
    
    /// <summary>
    /// чекаем игрока
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveController>())        //если это игрок
        {
            visualBullet.gameObject.SetActive(false);   // выкл
            Debug.Log(" Active false");
            if (particleSys)
            {
                particleSys.Play();
            }
        }
    }
}
