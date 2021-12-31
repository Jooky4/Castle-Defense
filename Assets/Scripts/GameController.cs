using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    Game,
    WinGame,
    LoseGame
}


/// <summary>
/// Game Controller ������ ����,�������� ������ �� ������, ������ � �����������
/// </summary>

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    //[SerializeField]
    [Header("��� ����� ����")]
    public int maxTimeGame = 10;

    [HideInInspector]
    public int currentTimerGame;

    //[Header("������ �� ������")]
    //public GameObject player;

    //[HideInInspector]
    //public CheckerItem checkerAirPlayer;

    //[Header("������ ����������� ")]
    //[SerializeField]
    //private List<GameObject> arrayEnemys;

    // [Header("������ �������")]
    // public List<Transform> arrayAirs;

    [Header("����� �� ������ ����������")]
    [SerializeField]
    public GameObject refPanelResult;

    [Header("����� �� ������ ������ ������")]
    [SerializeField]
    private GameObject refPanelWinGame;

    [Header("����� �� ������ ��������� ������")]
    [SerializeField]
    private GameObject refPanelLoseGame;


    [Header("�������� �� ��������� ������ Win/Lose")]
    [SerializeField]
    private float delayOnPanelWinLose = 1.0f;



    //[HideInInspector]
    public bool isPlayGame;

    //[HideInInspector]
    public StateGame stateGame;


    public int currentHealthCastle; // ������� �������� �����

    public int currentCountBots;   //  ������� ���-�� �����

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // checkerAirPlayer = player.GetComponent<CheckerItem>();
        // Time.timeScale = 0;
        isPlayGame = true;
        stateGame = StateGame.Game;
        currentTimerGame = maxTimeGame;
        StartCoroutine(TimerGame());

    }

    /// <summary>
    /// ����� ����
    /// </summary>
    //public Transform GetNewTarget(Transform positionObject)
    //{
    //    Transform currentPosition = null;

    //    if (arrayAirs.Count > 0)
    //    {
    //        float lastPosition = 100;

    //        foreach (Transform currentBaloon in arrayAirs)
    //        {
    //            //Transform currentChildBaloon = currentBaloon.GetComponentInChildren<AirScript>().gameObject.transform;
    //            float currentDistance = Vector3.Distance(currentChildBaloon.position, positionObject.position);

    //            if (currentChildBaloon.gameObject.activeInHierarchy)
    //            {
    //                if (lastPosition > currentDistance)
    //                {
    //                    currentPosition = currentChildBaloon;
    //                    lastPosition = currentDistance;
    //                }
    //            }
    //        }

    //    }
    //    return currentPosition;
    //}

    //public Transform GetNewTargetRamdom(Transform positionObject)
    //{
    //    Transform currentPosition = null;
    //    // if (arrayAirs.Count > 0)
    //    foreach (Transform currentBaloon in arrayAirs)
    //    {
    //        Transform targetPosition = arrayAirs[Random.Range(0, arrayAirs.Count)];

    //        if (targetPosition.GetComponentInChildren<AirScript>())
    //        {
    //            targetPosition = targetPosition.GetComponentInChildren<AirScript>().gameObject.transform;

    //            if (targetPosition.gameObject.activeInHierarchy)
    //            {
    //                return targetPosition;
    //            }
    //        }
    //    }
    //    return currentPosition;
    //}

    private void Update()
    {
        if (isPlayGame)
        {
            UpdateGame();
            UpdateStateGame();
        }
    }


    void UpdateGame()
    {
        if (currentHealthCastle == 0)
        {
            stateGame = StateGame.LoseGame;
        }

        if (currentCountBots == 0 && currentTimerGame == 0)
        {
            stateGame = StateGame.WinGame;
        }
    }



    /// <summary>
    /// ���������� ����
    /// </summary>
    public void UpdateStateGame()
    {

        if (stateGame == StateGame.LoseGame)
        {
            isPlayGame = false;
            Invoke("LoseGame", delayOnPanelWinLose);
        }

        if (stateGame == StateGame.WinGame)
        {
            isPlayGame = false;
            Invoke("WinGame", delayOnPanelWinLose);
        }

    }

    ///// <summary>
    ///// ��������� ���������� ������� ����� �� ���������
    ///// </summary>
    ///// <param name="platformForBallons"></param>
    ///// <returns></returns>
    //private bool CheckCountBallonsPlayers(PlatformForBallons platformForBallons)
    //{
    //    bool result = false;
    //    if (platformForBallons.currentCountBallonsPlanform == platformForBallons.maxCountBallons)
    //    {
    //        result = true;
    //    }

    //    return result;
    //}

    /// <summary>
    /// ����� ����
    /// </summary>
    public void StartGame()
    {
        //Time.timeScale = 1;
        isPlayGame = true;
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    public void EndGame()
    {
        Debug.Log("End Game");
        //Time.timeScale = 0;
        //isPlayGame = false;
        //refPanelResult.SetActive(false);
    }

    void WinGame()
    {
        EndGame();
        Debug.Log("Win Game");
        refPanelWinGame.SetActive(true);
    }

    void LoseGame()
    {
        EndGame();
        Debug.Log("Lose Game");
        refPanelLoseGame.SetActive(true);
    }

    private IEnumerator TimerGame()
    {
        while (currentTimerGame > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTimerGame--;

        }
    }

}
