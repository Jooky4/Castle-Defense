using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int maxHealthCastle = 0;

    [Header("Мах число бабла за игру")]
    public int maxMoneyGame = 100;

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

    [HideInInspector]
    public StateGame stateGame;

    [HideInInspector]
    public int currentHealthCastle; // текущее здоровье замка

    [HideInInspector]
    public int currentCountBots;   //  текущее кол-во ботов

    // [HideInInspector]
    public int currentMoney;   //  текущее кол-во бабла

    void Awake()
    {
        Instance = this;
        currentLevel = 1;
        PanelResult.SetActive(false);
        PanelWinGame.SetActive(false);
        PanelLoseGame.SetActive(false);
        spawnerBullets.gameObject.SetActive(false);
        spawnerBots.gameObject.SetActive(false);
        PanelStartGame.gameObject.SetActive(true);

        currentLevel = LoadData("LevelNumber");

        maxHealthCastle = LoadData("MaxHealthCastle");
        if (maxHealthCastle == 0)
        {
            maxHealthCastle = SetRandomHealth(currentLevel);
            SaveData("MaxHealthCastle", maxHealthCastle);                            // сохраняем мах колво жизней на уровне
        }

        currentMoney = LoadData("Money");

        SetLoadScene(currentLevel);
    }


    void Start()
    {
        if (currentLevel == 0)
        {
            currentLevel = 1;
        }
        currentCountBots = maxCountBots;
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
        SaveData("LevelNumber", currentLevel);                            // сохраняем номер level
        SaveData("Money", currentMoney);                                 // сохраняем колво денег

        Debug.Log("End Game");
    }


    /// <summary>
    /// Победа
    /// </summary>
    void WinGame()
    {
        currentLevel++;
        currentMoney += maxMoneyGame;

        maxHealthCastle = SetRandomHealth(currentLevel);
        SaveData("MaxHealthCastle", maxHealthCastle);                            // сохраняем мах колво жизней на уровне

        EndGame();
        Debug.Log("Win Game");

        PanelWinGame.SetActive(true);
    }


    /// <summary>
    /// Проигрыш
    /// </summary>
    void LoseGame()
    {
        EndGame();

        Debug.Log("Lose Game");
        PanelLoseGame.SetActive(true);
    }


    /// <summary>
    /// Таймер игры
    /// </summary>
    /// <returns></returns>
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
    /// Установка случайного значения здоровья замка
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    int SetRandomHealth(int currentLevel)
    {
        int result = 0;

        if (currentLevel >= 1 && currentLevel <= 5)
        {
            result = Random.Range(15, 21);
        }

        if (currentLevel >= 6 && currentLevel <= 10)
        {
            result = Random.Range(10, 16);
        }

        if (currentLevel >= 11 && currentLevel <= 20)
        {
            result = Random.Range(5, 11);
        }

        if (currentLevel > 20)
        {
            result = Random.Range(5, 11);
        }

        Debug.Log(" result " + result);
        return result;
    }

    /// <summary>
    /// Выбор сцены для загрузки
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    int SetLoadScene(int currentLevel)
    {
        int result = 0;

        if (currentLevel >= 1 && currentLevel <= 5)
        {
            LoadScene(0);
        }

        if (currentLevel >= 6 && currentLevel <= 10)
        {
            LoadScene(1);
        }

        if (currentLevel >= 11 && currentLevel <= 20)
        {
            LoadScene(2);
        }

        if (currentLevel > 20)
        {
            LoadScene(2);
        }

        Debug.Log(" result " + result);
        return result;
    }



    /// <summary>
    /// 
    /// </summary>
    public void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   // текущая сцена

        SceneManager.LoadScene(currentScene);            // текущая сцена

    }

    public void LoadScene(int currentScene)
    {
        if (currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(currentScene);
        }
    }





    /// <summary>
    /// Сохранение данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    public void SaveData(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadData(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
