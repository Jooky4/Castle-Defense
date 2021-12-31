using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullets : MonoBehaviour
{
    [SerializeField]
    [Header("Таймер спавна снарядов")]
    private float timerSpawnBullets;

    [SerializeField]
    [Header("Кол-во снарядов за спавн")]
    private int countSpawnBullets;

    [Header("Префаб снаряда")]
    [SerializeField]
    private Transform prefabBullet;

    [HideInInspector]
    public Transform[] poolBullets;

    [SerializeField]
    [Header("Длина области спавна снаряда")]
    private int length;

    [SerializeField]
    [Header("Ширина области спавна снаряда")]
    private int width;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
