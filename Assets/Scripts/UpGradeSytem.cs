using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeSytem : MonoBehaviour
{
    [HideInInspector]
    public int upgradeDoubleShootLevel;           // текущий Level DoubleShoot
    [HideInInspector]
    public int upgradeSpeedHeroLevel;             // текущий Level SpeedHero


    [Header("Начальная цена прокачки DoubleShoot")]
    [SerializeField]
    private int startPriceDoubleShoot;
    [Header("Следующая цена прокачки DoubleShoot")]
    [SerializeField]
    private int nextPriceDoubleShoot;

    [Header("Начальная цена прокачки SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;
    [Header("Следующая цена прокачки SpeedHero")]
    [SerializeField]
    private int nextPriceSpeedHero;


    [SerializeField]
    private int currentPriceDoubleShoot;        // текущая цена 
    [SerializeField]
    private int currentPriceSpeedHero;          // текущая цена 


    [SerializeField]
    private int allMoney;                    // все деньхи



    void Start()
    {
        allMoney = GameController.Instance.allMoney;

        upgradeDoubleShootLevel = GameController.Instance.LoadData("upgradeDoubleShootLevel");
        upgradeSpeedHeroLevel = GameController.Instance.LoadData("upgradeSpeedHeroLevel");

        ShowUI();

    }

    //SaveData("Money", saveMoney);                                 // сохраняем колво денег
    //allMoney = LoadData("Money");


    /// <summary>
    /// Покупаем прокачку 
    /// </summary>
    public void BuyUpgradeDoubleShoot()
    {
        if (allMoney > currentPriceDoubleShoot)
        {
            allMoney -= currentPriceDoubleShoot;
            upgradeDoubleShootLevel++;
            GameController.Instance.allMoney = allMoney;
            GameController.Instance.SaveData("upgradeDoubleShootLevel", upgradeDoubleShootLevel);
            GameController.Instance.SaveData("Money", allMoney);
            ShowUI();
        }
    }


    /// <summary>
    /// Покупаем прокачку 
    /// </summary>
    public void BuyUpgradeSpeedHero()
    {
        if (allMoney > currentPriceSpeedHero)
        {
            allMoney -= currentPriceSpeedHero;
            upgradeSpeedHeroLevel++;
            GameController.Instance.allMoney = allMoney;
            GameController.Instance.SaveData("upgradeSpeedHeroLevel", upgradeSpeedHeroLevel);
            GameController.Instance.SaveData("Money", allMoney);
            ShowUI();
        }
    }


    /// <summary>
    /// Показываем данные прокачки
    /// </summary>
    void ShowUI()
    {
        currentPriceDoubleShoot = startPriceDoubleShoot + nextPriceDoubleShoot * upgradeDoubleShootLevel;
        currentPriceSpeedHero = startPriceSpeedHero + nextPriceSpeedHero * upgradeSpeedHeroLevel;

        GameController.Instance.upgradeDobleShootLevel = upgradeDoubleShootLevel;
        GameController.Instance.currentPriceDoubleShoot = currentPriceDoubleShoot;
        GameController.Instance.upgradeSpeedHeroLevel = upgradeSpeedHeroLevel;
        GameController.Instance.currentPriceSpeedHero = currentPriceSpeedHero;
    }

}
