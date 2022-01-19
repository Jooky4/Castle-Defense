
// ГАВНА Скрипт висит на SpawnerBots
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// создает ботов на поле и спавнит их 
/// </summary>
public class SpawnerBots : MonoBehaviour
{
    [SerializeField]
    [Header("Таймер спавна ботов")]
    private float timerSpawnBots;

    [SerializeField]
    [Header("Кол-во ботов за спавн")]
    private int countSpawnBots;

    [Header("Позиция Y Бота")]
    [SerializeField]
    private Transform PosYInstantiateBot;

    [Header("Префаб бота")]
    [SerializeField]
    private Transform[] prefabBot;

    //[SerializeField]
    private int[] arrayPercentChoice;    // массив выбора бота в процентах

    [HideInInspector]
    public Transform[] poolBots;

    [SerializeField]
    [Header("Массив границ спавна")]
    public Transform[] bordersSpawn;

    [SerializeField]
    private Transform[] TargetsBots;

    private int lastIndex;   // последний элемент массива

    void Start()
    {
        ConvertPercentChoiceBots();

        foreach (Transform border in bordersSpawn) // выкл границы спавна
        {
            border.gameObject.SetActive(false);
        }

        InstantiateBots();
        SetPositionBots();
        StartCoroutine(SpawnBots());
    }

    /// <summary>
    /// Преобразуем для расчета
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
    /// создаем бота
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
    /// Выбор рамдомного бота
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
    /// положение бота
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
    /// спавн (вкл) с задержкой
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
    /// Сетит цель
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
