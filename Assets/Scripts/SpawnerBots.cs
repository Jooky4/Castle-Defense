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
    [Header("����� ������� ������ ����")]
    private int length;

    [SerializeField]
    [Header("������ ������� ������ ����")]
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
