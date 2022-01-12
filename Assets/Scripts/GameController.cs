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
/// Game Controller логика игры,содержит ссылки на игрока, шарики и противников
/// </summary>

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("МАХ время игры")]
    public int maxTimeGame = 10;

    [Header("Мах число жизней замка")]
    public int maxHealthCastle = 20;

    [HideInInspector]
    public int currentTimerGame;

    [Header("Ссыль SpawnerBots")]
    [SerializeField]
    public SpawnerBots spawnerBots;

    [Header("Ссыль SpawnerBullets")]
    [SerializeField]
    public SpawnerBullets spawnerBullets;

    [Header("Кол-во Spawn снарядов в начале игры")]
    [SerializeField]
    public int countBulletsStartGame;

    [Header("Ссыль на панель Старт Игра")]
    [SerializeField]
    public GameObject PanelStartGame;

    [Header("Ссыль на панель результата")]
    [SerializeField]
    public GameObject PanelResult;

    [Header("Ссыль на панель Победы игрока")]
    [SerializeField]
    private GameObject PanelWinGame;

    [Header("Ссыль на панель Поражения игрока")]
    [SerializeField]
    private GameObject PanelLoseGame;

    [Header("Задержка на появление панель Win/Lose")]
    [SerializeField]
    private float delayOnPanelWinLose = 1.0f;

    [SerializeField]
    [Header("Мах кол-во ботов")]
    private int maxCountBots = 10;

    [HideInInspector]
    public int currentLevel;   //   текущий уровень 

    [HideInInspector]
    public bool isPlayGame;

    //[HideInInspector]
    public StateGame stateGame;

    // [HideInInspector]
    public int currentHealthCastle; // текущее здоровье замка

    // [HideInInspector]
    public int currentCountBots;   //  текущее кол-во ботов

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
    /// обновления игры
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
    /// старт игры
    /// </summary>
    public void StartGame()
    {
        stateGame = StateGame.Game;
        spawnerBullets.gameObject.SetActive(true);
        spawnerBots.gameObject.SetActive(true);
        PanelResult.SetActive(true);
    }

    /// <summary>
    /// конец игры
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
    /// Загрузка данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadLevelNumber(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
