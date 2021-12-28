using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBots : MonoBehaviour
{
    [SerializeField]
    [Header("������ ������ �����")]
    private float timerSpawnBots;

    [SerializeField]
    [Header("���-�� ����� �� �����")]
    private int countSpawnBots;

    [Header("������ ����")]
    [SerializeField]
    private Transform prefabBot;

    [HideInInspector]
    public Transform[] poolBots;

    [SerializeField]
    [Header("������ ������ ������")]
    public Transform[] bordersSpawn;

    [SerializeField]
    private int countBots;

    // Start is called before the first frame update
    void Start()
    {
       countBots = (int)(countSpawnBots * (GameController.Instance.maxTimeGame / timerSpawnBots));
        //countBots /= 2;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
