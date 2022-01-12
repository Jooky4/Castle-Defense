// Скрипт висит на SpawnerBullets

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
    private void InstantiateBullets()
    {
        int countBullets = (int)(countSpawnBullets * (GameController.Instance.maxTimeGame / timerSpawnBullets));

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

    IEnumerator CoroutineSpawnBullets()
    {
       
        while (GameController.Instance.stateGame == StateGame.Game)
        {
            SpawnBullets();

            yield return new WaitForSeconds(timerSpawnBullets);
        }
    }

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

    void SpawnBullets()
    {
        int index;

        for (index = lastIndex; index < lastIndex + countSpawnBullets; index++)
        {
            if (poolBullets[index] != null)
            {
                poolBullets[index].gameObject.SetActive(true);
            }
        }

        lastIndex = index;

        if (lastIndex >= poolBullets.Length)
        {
            lastIndex = 0;
        }
    }

    void StartSpawn(int countBulletsStartGame)
    {
        for (int i = 0; i < countBulletsStartGame; i++)
        {
            SpawnBullets();
        }
    }

}

