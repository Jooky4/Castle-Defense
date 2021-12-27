using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBots : MonoBehaviour
{
    [SerializeField]
    [Header("Таймер спавна ботов")]
    private float timerSpawnBots;

    [SerializeField]
    [Header("Кол-во ботов за спавн")]
    private int countSpawnBots;

    [Header("Префаб бота")]
    [SerializeField]
    private Transform prefabBot;

    [HideInInspector]
    public Transform[] poolBots;

    [SerializeField]
    [Header("Длина области спавна бота")]
    private int length;

    [SerializeField]
    [Header("Ширина области спавна бота")]
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
