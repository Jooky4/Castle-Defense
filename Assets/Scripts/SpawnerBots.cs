
// ����� ������ ����� �� SpawnerBots
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ������� ����� �� ���� � ������� �� 
/// </summary>
public class SpawnerBots : MonoBehaviour
{
    [SerializeField]
    [Header("������ ������ �����")]
    private float timerSpawnBots;

    [SerializeField]
    [Header("���-�� ����� �� �����")]
    private int countSpawnBots;

    [Header("������� Y ����")]
    [SerializeField]
    private Transform PosYInstantiateBot;

    [Header("������ ����")]
    [SerializeField]
    private Transform[] prefabBot;

    //[SerializeField]
    private int[] arrayPercentChoice;    // ������ ������ ���� � ���������

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
        ConvertPercentChoiceBots();

        foreach (Transform border in bordersSpawn) // ���� ������� ������
        {
            border.gameObject.SetActive(false);
        }

        InstantiateBots();
        SetPositionBots();
        StartCoroutine(SpawnBots());
    }

    /// <summary>
    /// ����������� ��� �������
    /// </summary>
   void ConvertPercentChoiceBots()
    {
        arrayPercentChoice = new int[prefabBot.Length];
        int lastArrayPercentChoice = 0;
        for (int i = 0; i < prefabBot.Length; i++)
        {
            arrayPercentChoice[i] = lastArrayPercentChoice + prefabBot[i].GetComponent<EnemyController>().percentChoiceBot;

            lastArrayPercentChoice = arrayPercentChoice[i];

        }
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    private void InstantiateBots()
    {
        int countBots = (int)(countSpawnBots * (GameController.Instance.maxTimeGame / timerSpawnBots));
        poolBots = new Transform[countBots];

        for (int index = 0; index < poolBots.Length; index++)
        {
            int indexPrefabBot = RandomChoicePrefabBot();
            Vector3 positionBot = new Vector3(Random.Range(bordersSpawn[0].position.x, bordersSpawn[1].position.x), PosYInstantiateBot.position.y, Random.Range(bordersSpawn[0].position.z, bordersSpawn[1].position.z));
            poolBots[index] = Instantiate(prefabBot[indexPrefabBot], positionBot, Quaternion.identity);
        }
    }

    /// <summary>
    /// ����� ���������� ����
    /// </summary>
    /// <returns></returns>
    int RandomChoicePrefabBot()
    {
        int result = 0;

        int randomPercent = Random.Range(0, 101);

        for (int i = 0; i < arrayPercentChoice.Length; i++)
        {
            int percentChoiceBot = arrayPercentChoice[i];

            if (randomPercent < percentChoiceBot)
            {
                result = i;
                break;
            }
        }

        return result;
    }


    /// <summary>
    /// ��������� ����
    /// </summary>
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


    /// <summary>
    /// ����� (���) � ���������
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// ����� ����
    /// </summary>
    /// <param name="currentObject"></param>
    /// <returns></returns>
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
