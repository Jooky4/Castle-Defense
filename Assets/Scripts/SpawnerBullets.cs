// Скрипт висит на SpawnerBullets

using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        // thisObjectTransform = transform;
        foreach (Transform border in bordersSpawn)
        {
            border.gameObject.SetActive(false);
        }

        InstantiateBullets();
        SetActiveBots();
        StartCoroutine(SpawnBullets());
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void InstantiateBullets()
    {
        int countBullets = (int)(countSpawnBullets * (GameController.Instance.maxTimeGame / timerSpawnBullets));

        poolBullets = new Transform[countBullets];

        for (int index = 0; index < poolBullets.Length; index++)
        {
            for (int i = 0; i < 5; i++)
            {
                positionBullet = new Vector3(Random.Range(bordersSpawn[0].position.x, bordersSpawn[1].position.x),
                                     prefabBullet.position.y, Random.Range(bordersSpawn[0].position.z, bordersSpawn[1].position.z));

                if (SetPositionBots(index))
                //if (SetPositionBots(index, "test"))
                {
                    break;
                }
            }

            //EnemyController enemyController = poolBots[index].gameObject.GetComponent<EnemyController>();
            // enemyController.currentTarget = SetTarget(poolBots[index]);
            // poolBots[index].gameObject.SetActive(false);
        }
        Debug.Log("InstantiateBullets");
    }

    private bool SetPositionBots(int index)
    {
        bool result = false;

        Vector3 beginRay = positionBullet + Vector3.up;

        Vector3 finishRay = positionBullet - Vector3.up * 2.0f;

        Debug.DrawLine(beginRay, finishRay, Color.red, 1.0f);

        RaycastHit hit;

        if (Physics.Raycast(beginRay, finishRay, out hit, Mathf.Infinity))
        {
            if (hit.transform.GetComponent<Bullet>())
            {
                Debug.Log(hit.transform.name);
            }
            else
            {
                poolBullets[index] = Instantiate(prefabBullet, positionBullet, Quaternion.identity);
                result = true;

            }
        }
        return result;
    }

    private void SetActiveBots()
    {
        for (int index = 0; index < poolBullets.Length; index++)
        {
            poolBullets[index].gameObject.SetActive(false);
        }
    }

    IEnumerator SpawnBullets()
    {
        int index;

        while (GameController.Instance.stateGame == StateGame.Game)
        {
            for (index = lastIndex; index < lastIndex + countSpawnBullets; index++)
            {
                poolBullets[index].gameObject.SetActive(true);
            }
            lastIndex = index;
            if (lastIndex >= poolBullets.Length)
            {
                lastIndex = 0;
            }

            yield return new WaitForSeconds(timerSpawnBullets);
        }
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
    //    if (m_Started)
    //        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    //        Gizmos.DrawWireCube(poolBullets[index].position, poolBullets[index].localScale);
    //}


    private bool SetPositionBots(int index, string test)
    {
        bool result = false;

        Collider[] hitColliders = Physics.OverlapBox(positionBullet, prefabBullet.localScale, Quaternion.identity);

        int i = 0;

        while (i < hitColliders.Length)
        {
            if (hitColliders[i].transform.GetComponent<Bullet>())
            {
                Debug.Log(hitColliders[i].transform.name);
            }
            else
            {
                poolBullets[index] = Instantiate(prefabBullet, positionBullet, Quaternion.identity);
                result = true;
                break;
            }
            //Debug.Log("Hit : " + hitColliders[i].name + i);
            i++;
        }

        return result;
    }
}

