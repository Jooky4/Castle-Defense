// ГАВНА Скрипт висит на SpawnerBullets

using System.Collections;
using UnityEngine;


/// <summary>
/// создает снаряды на поле и спавнит их 
/// </summary>
public class SpawnerBullets : MonoBehaviour
{
    [SerializeField]
    [Header("Таймер спавна снарядов")]
    private float timerSpawnBullets;

    [SerializeField]
    [Header("Кол-во снарядов за спавн")]
    private int countSpawnBullets;

    [Header("Позиция Y снаряда")]
    [SerializeField]
    private Transform PosYInstantiateBullet;

    [Header("Префаб снаряда")]
    [SerializeField]
    private Transform prefabBullet;

    //[HideInInspector]
    public Transform[] poolBullets;

    [SerializeField]
    [Header("Массив границ спавна")]
    public Transform[] bordersSpawn;

    private int lastIndex;   // последний элемент массива

    private Vector3 positionBullet;

    void Start()
    {
        foreach (Transform border in bordersSpawn)
        {
            border.gameObject.SetActive(false);
        }

        InstantiateBullets();
        SetActiveBots();
        StartSpawn(GameController.Instance.countBulletsStartGame);
        StartCoroutine(CoroutineSpawnBullets());
    }

    /// <summary>
    /// создаем снаряды на поле
    /// </summary>
    private void InstantiateBullets()
    {
        int countBullets = (int)(countSpawnBullets * (GameController.Instance.maxTimeGame / timerSpawnBullets));
        countBullets += GameController.Instance.countBulletsStartGame;

        poolBullets = new Transform[countBullets];

        positionBullet = new Vector3(Random.Range(bordersSpawn[0].position.x, bordersSpawn[1].position.x),
                                     PosYInstantiateBullet.position.y, Random.Range(bordersSpawn[0].position.z, bordersSpawn[1].position.z));

        poolBullets[0] = Instantiate(prefabBullet, positionBullet, Quaternion.identity);

        for (int index = 1; index < poolBullets.Length; index++)
        {
            for (int i = 0; i < 1000; i++)
            {
                positionBullet = new Vector3(Random.Range(bordersSpawn[0].position.x, bordersSpawn[1].position.x),
                                     PosYInstantiateBullet.position.y, Random.Range(bordersSpawn[0].position.z, bordersSpawn[1].position.z));

                if (SetPositionBots(index))
                {
                    poolBullets[index] = Instantiate(prefabBullet, positionBullet, Quaternion.identity);
                    //Debug.Log(" попыток = " + i);
                    break;
                }
            }
        }
        // Debug.Log("InstantiateBullets");
    }

    /// <summary>
    /// выкл снаряды на поле
    /// </summary>
    private void SetActiveBots()
    {
        for (int index = 0; index < poolBullets.Length; index++)
        {
            if (poolBullets[index] != null)
            {
                poolBullets[index].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// таймер спавна снарядов
    /// </summary>
    /// <returns></returns>
    IEnumerator CoroutineSpawnBullets()
    {
       
        while (GameController.Instance.stateGame == StateGame.Game)
        {
            yield return new WaitForSeconds(timerSpawnBullets);

            SpawnBullets(countSpawnBullets);
        }
    }

    /// <summary>
    /// находим позицию для снаряда на поле
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool SetPositionBots(int index)
    {
        bool result = false;

        for (int i = 0; i < poolBullets.Length; i++)
        {
            if (poolBullets[i] != null)
            {
                if (Vector3.Distance(poolBullets[i].position, positionBullet) < prefabBullet.localScale.magnitude / 1.5f)
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// спавн снарядов с задержкой
    /// </summary>
    /// <param name="countSpawnBullets"></param>
    void SpawnBullets(int countSpawnBullets)
    {
        //int index = lastIndex;

        // for(int i = 0; i < countSpawnBullets; i++)
        // //for (index = lastIndex; index < lastIndex + countSpawnBullets; index++)
        // {

        //     if (poolBullets[index] != null)
        //     {
        //         Debug.Log(index);
        //         poolBullets[index].gameObject.SetActive(true);
        //     }
        //     index++;
        // }

        // lastIndex = index;

        // if (lastIndex >= poolBullets.Length)
        // {
        //     lastIndex = 0;
        // }


        for (int i = 0; i < countSpawnBullets; i++)
        {

            if (poolBullets[lastIndex] != null)
            {
               // Debug.Log(lastIndex);
                poolBullets[lastIndex].gameObject.SetActive(true);
            }
            lastIndex++;

            if (lastIndex >= poolBullets.Length)
            {
                lastIndex = 0;
            }
        }
    }


    /// <summary>
    /// спавн снарядов при старте
    /// </summary>
    /// <param name="countBulletsStartGame"></param>
    void StartSpawn(int countBulletsStartGame)
    {
        for (int i = 0; i < countBulletsStartGame; i++)
        {
            SpawnBullets(1);
        }
    }

}

