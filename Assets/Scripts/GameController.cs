using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    Start,
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

    [Header("��� ����� ����")]
    public int maxTimeGame = 10;

    [Header("��� ����� ������ �����")]
    public int maxHealthCastle = 20;

    [HideInInspector]
    public int currentTimerGame;

    [Header("����� SpawnerBots")]
    [SerializeField]
    public SpawnerBots spawnerBots;

    [Header("����� SpawnerBullets")]
    [SerializeField]
    public SpawnerBullets spawnerBullets;

    [Header("���-�� Spawn �������� � ������ ����")]
    [SerializeField]
    public int countBulletsStartGame;

    [Header("����� �� ������ ����� ����")]
    [SerializeField]
    public GameObject PanelStartGame;

    [Header("����� �� ������ ����������")]
    [SerializeField]
    public GameObject PanelResult;

    [Header("����� �� ������ ������ ������")]
    [SerializeField]
    private GameObject PanelWinGame;

    [Header("����� �� ������ ��������� ������")]
    [SerializeField]
    private GameObject PanelLoseGame;

    [Header("�������� �� ��������� ������ Win/Lose")]
    [SerializeField]
    private float delayOnPanelWinLose = 1.0f;

    [SerializeField]
    [Header("��� ���-�� �����")]
    private int maxCountBots = 10;

    [HideInInspector]
    public int currentLevel;   //   ������� ������� 

    [HideInInspector]
    public bool isPlayGame;

    //[HideInInspector]
    public StateGame stateGame;

    // [HideInInspector]
    public int currentHealthCastle; // ������� �������� �����

    // [HideInInspector]
    public int currentCountBots;   //  ������� ���-�� �����

    void Awake()
    {
        //if (Instance == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        Instance = this;
        PanelResult.SetActive(false);
        PanelWinGame.SetActive(false);
        PanelLoseGame.SetActive(false);
        spawnerBullets.gameObject.SetActive(false);
        spawnerBots.gameObject.SetActive(false);
        PanelStartGame.gameObject.SetActive(true);
        //}
        //else if (Instance != this)
        //{
        //    Destroy(gameObject);
        //}
    }


    void Start()
    {




        currentLevel = LoadLevelNumber("LevelNumber");
        currentCountBots = maxCountBots;
        // checkerAirPlayer = player.GetComponent<CheckerItem>();
        // Time.timeScale = 0;
        isPlayGame = true;
        stateGame = StateGame.Start;
        currentTimerGame = maxTimeGame;
        StartCoroutine(TimerGame());
    }

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
        if (currentHealthCastle <= 0)
        {
            stateGame = StateGame.LoseGame;
        }

        if (currentTimerGame <= 0)

        //if (currentCountBots <= 0 && currentTimerGame <= 0)
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
            EndGame();
            Invoke("LoseGame", delayOnPanelWinLose);
        }

        if (stateGame == StateGame.WinGame)
        {
            isPlayGame = false;
            EndGame();
            Invoke("WinGame", delayOnPanelWinLose);
        }
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    public void StartGame()
    {
        stateGame = StateGame.Game;
        spawnerBullets.gameObject.SetActive(true);
        spawnerBots.gameObject.SetActive(true);
        PanelResult.SetActive(true);
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    public void EndGame()
    {
        spawnerBullets.gameObject.SetActive(false);
        spawnerBots.gameObject.SetActive(false);
        PanelResult.SetActive(false);

        Debug.Log("End Game");
    }

    void WinGame()
    {
        EndGame();
        Debug.Log("Win Game");
        PanelWinGame.SetActive(true);
    }

    void LoseGame()
    {
        EndGame();
        Debug.Log("Lose Game");
        PanelLoseGame.SetActive(true);
    }

    private IEnumerator TimerGame()
    {
        while (currentTimerGame > 0)
        {
            yield return new WaitForSeconds(1.0f);

            if (stateGame == StateGame.Game)
            {
                currentTimerGame--;
            }
        }
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadLevelNumber(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
