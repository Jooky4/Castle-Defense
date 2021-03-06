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
/// Game Controller ?????? ????,???????? ?????? ?? ??????, ?????? ? ???????????
/// </summary>

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [HideInInspector]
    public int countDeadBots;

    [Header("??? ????? ????")]
    public int maxTimeGame = 10;

    [Header("??? ????? ?????? ?????")]
    public int maxHealthCastle = 10;

    [Header("??? ????? ????? ?? ????")]
    public int maxMoneyGame = 100;

    [HideInInspector]
    public int currentTimerGame;

    [Header("????? SpawnerBots")]
    [SerializeField]
    public SpawnerBots spawnerBots;

    [Header("????? SpawnerBullets")]
    [SerializeField]
    public SpawnerBullets spawnerBullets;

    [Header("???-?? Spawn ???????? ? ?????? ????")]
    [SerializeField]
    public int countBulletsStartGame;

    [Header("????? ?? ?????? ????? ????")]
    [SerializeField]
    public GameObject PanelStartGame;

    [Header("????? ?? ?????? ??????????")]
    [SerializeField]
    public GameObject PanelResult;

    [Header("????? ?? ?????? ?????? ??????")]
    [SerializeField]
    private GameObject PanelWinGame;

    [Header("????? ?? ?????? ????????? ??????")]
    [SerializeField]
    private GameObject PanelLoseGame;

    [Header("???????? ?? ????????? ?????? Win/Lose")]
    [SerializeField]
    private float delayOnPanelWinLose = 1.0f;

    [SerializeField]
    [Header("??? ???-?? ?????")]
    private int maxCountBots = 10;

    [HideInInspector]
    public int currentLevel;   //   ??????? ??????? 

    [HideInInspector]
    public bool isPlayGame;

    [HideInInspector]
    public StateGame stateGame;

    [HideInInspector]
    public int currentHealthCastle; // ??????? ???????? ?????

    [HideInInspector]
    public int currentCountBots;   //  ??????? ???-?? ?????

    [HideInInspector]
    public int currentMoney;   //  ??????? ???-?? ?????

    [HideInInspector]
    public int allMoney;      // ????? ?????

    [HideInInspector]
    public int currentIDSkin;   // ??????? ID skin

    [HideInInspector]
    public int currentIDWeapon;   // ??????? ID weapon

    [HideInInspector]
    public int upgradeDobleShootLevel;     //  // ??????? Level DoubleShoot

    [HideInInspector]
    public int currentPriceDoubleShoot;    // ???? ???????? DoubleShoot

    [HideInInspector]
    public int upgradeSpeedHeroLevel;      //  // ??????? Level SpeedHero

    [HideInInspector]
    public int currentPriceSpeedHero;     // ???? ???????? SpeedHero


    void Awake()
    {
        Instance = this;
        //currentLevel = 1;
        PanelResult.SetActive(false);
        PanelWinGame.SetActive(false);
        PanelLoseGame.SetActive(false);
        spawnerBullets.gameObject.SetActive(false);
        spawnerBots.gameObject.SetActive(false);
        PanelStartGame.gameObject.SetActive(true);

        currentLevel = LoadData("LevelNumber");

        //maxHealthCastle = LoadData("MaxHealthCastle");

        if (currentLevel == 0)
        {
            currentLevel = 1;
        }

        //if (maxHealthCastle == 0)
        //{
        //    maxHealthCastle = SetRandomHealth(currentLevel);
        //    SaveData("MaxHealthCastle", maxHealthCastle);                            // ????????? ??? ????? ?????? ?? ??????
        //}


        //currentMoney = LoadData("Money");
        allMoney = LoadData("Money");
        currentIDSkin = LoadData("SavedIDSkin");
        currentIDWeapon = LoadData("SavedIDWeapon");
        //PlayerPrefs.SetInt("SavedIDWeapon", currentIDWeapon);

        SetLoadScene(currentLevel);
    }


    void Start()
    {
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
    /// ?????????? ????
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
    /// ????? ????
    /// </summary>
    public void StartGame()
    {
        stateGame = StateGame.Game;
        spawnerBullets.gameObject.SetActive(true);
        spawnerBots.gameObject.SetActive(true);
        PanelResult.SetActive(true);
    }

    /// <summary>
    /// ????? ????
    /// </summary>
    public void EndGame()
    {
        spawnerBullets.gameObject.SetActive(false);
        spawnerBots.gameObject.SetActive(false);
        PanelResult.SetActive(false);
        SaveData("LevelNumber", currentLevel);                            // ????????? ????? level

        int saveMoney = currentMoney + allMoney;
        SaveData("Money", saveMoney);                                 // ????????? ????? ?????
        StartCoroutine(ShowAnimationMoney());
        Debug.Log("End Game");
    }


    /// <summary>
    /// ??????
    /// </summary>
    void WinGame()
    {
        currentLevel++;
        currentMoney += maxMoneyGame;

        //maxHealthCastle = SetRandomHealth(currentLevel);
        //SaveData("MaxHealthCastle", maxHealthCastle);                            // ????????? ??? ????? ?????? ?? ??????

        EndGame();
        Debug.Log("Win Game");

        PanelWinGame.SetActive(true);
    }


    /// <summary>
    /// ????????
    /// </summary>
    void LoseGame()
    {
        EndGame();

        Debug.Log("Lose Game");
        PanelLoseGame.SetActive(true);
    }

    private IEnumerator ShowAnimationMoney()
    {
        print("ShowAnimationMoney");
        while (currentMoney > 0)
        {
            currentMoney--;
            allMoney++;
            yield return new WaitForEndOfFrame();
        }
    }



    /// <summary>
    /// ?????? ????
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
    /// ????? ????? ??? ????????
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    int SetLoadScene(int currentLevel)
    {
        int result = 0;

        if (currentLevel > 20)
        {
            LoadScene(Random.Range(0, 21));
        }
        else
        {
            LoadScene(currentLevel);
        }
        return result;
    }

    //if (currentScene != SceneManager.GetActiveScene().buildIndex)
    //{
    //    SceneManager.LoadScene(currentScene);
    //}

    public void LoadScene(int currentScene)
    {
       

        int tempLoadScene = currentScene - 1;

        print(" currentScene " + currentScene);
        print(" currentLevel " + currentLevel);
        print(" SceneManager.sceneCountInBuildSettings " + (SceneManager.sceneCountInBuildSettings - 2));
        print(" tempLoadScene " + tempLoadScene);

        if (SceneManager.GetActiveScene().buildIndex != tempLoadScene)
        {

            if ((SceneManager.sceneCountInBuildSettings - 2) >= tempLoadScene)
            {
                tempLoadScene = currentScene - 1;

                SceneManager.LoadScene(tempLoadScene);
            }
            else
            {
                return;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);                          // ??????? ?????
            }
        }
        else
        {
            return;

        }
    }





    /// <summary>
    /// ?????????? ??????
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    public void SaveData(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    /// <summary>
    /// ???????? ??????
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadData(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
