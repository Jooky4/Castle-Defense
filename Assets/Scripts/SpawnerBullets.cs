using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullets : MonoBehaviour
{
    [SerializeField]
    [Header("������ ������ ��������")]
    private float timerSpawnBullets;

    [SerializeField]
    [Header("���-�� �������� �� �����")]
    private int countSpawnBullets;

    [Header("������ �������")]
    [SerializeField]
    private Transform prefabBullet;

    [HideInInspector]
    public Transform[] poolBullets;

    [SerializeField]
    [Header("����� ������� ������ �������")]
    private int length;

    [SerializeField]
    [Header("������ ������� ������ �������")]
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
