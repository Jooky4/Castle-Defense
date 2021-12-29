using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
    private Transform[] TargetsBots;


    private int lastIndex;   // ��������� ������� �������

    void Start()
    {
        // thisObjectTransform = transform;
        foreach (Transform border in bordersSpawn)
        {
            border.gameObject.SetActive(false);
        }

        InstantiateBots();
        SetPositionBots();
        StartCoroutine(SpawnBots());

    }

    void Update()
    {

    }

    private void InstantiateBots()
    {
        int countBots = (int)(countSpawnBots * (GameController.Instance.maxTimeGame / timerSpawnBots));
        poolBots = new Transform[countBots];
        for (int index = 0; index < poolBots.Length; index++)
        {
            Vector3 positionBot = new Vector3(Random.Range(bordersSpawn[0].position.x, bordersSpawn[1].position.x), prefabBot.position.y, Random.Range(bordersSpawn[0].position.z, bordersSpawn[1].position.z));
            poolBots[index] = Instantiate(prefabBot, positionBot, Quaternion.identity);
            //EnemyController enemyController = poolBots[index].gameObject.GetComponent<EnemyController>();
            // enemyController.currentTarget = SetTarget(poolBots[index]);
            // poolBots[index].gameObject.SetActive(false);
        }
    }

    private void SetPositionBots()
    {
        for (int index = 0; index < poolBots.Length; index++)
        {
            EnemyController enemyController = poolBots[index].gameObject.GetComponent<EnemyController>();
            enemyController.currentTarget = SetTarget(poolBots[index]);
            enemyController.lastPosition = enemyController.transform.position;
            poolBots[index].gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnBots()
    {
        int index;

        while (GameController.Instance.stateGame == StateGame.Game)
        {
            for (index = lastIndex; index < lastIndex + countSpawnBots; index++)
            {
                poolBots[index].transform.position = poolBots[index].GetComponent<EnemyController>().lastPosition;
                poolBots[index].gameObject.SetActive(true);
            }
            lastIndex = index;
            if (lastIndex >= poolBots.Length)
            {
                lastIndex = 0;
            }

            yield return new WaitForSeconds(timerSpawnBots);
        }
    }

    Transform SetTarget(Transform currentObject)
    {
        Transform currentTarget = TargetsBots[0];

        float lastDistance = Vector3.Distance(currentObject.position, currentTarget.position); ;
        foreach (Transform targetBot in TargetsBots)
        {
            float currentDistance = Vector3.Distance(currentObject.position, targetBot.position);

            if (currentDistance < lastDistance)
            {
                currentTarget = targetBot;
                lastDistance = currentDistance;
            }
        }

        return currentTarget;
    }
}
