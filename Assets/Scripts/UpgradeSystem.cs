using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [HideInInspector]
    public int upgradeDobleShootLevel = 1;

    [Header("Начальная цена прокачки DobleShoot")]
    [SerializeField]
    private int startPriceDobleShoot;

    [SerializeField]
    private int upgradeDobleShootPrice;

    [HideInInspector]
    public int upgradeSpeedHeroLevel = 1;

    [Header("Начальная цена прокачки SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;

    [SerializeField]
    private int upgradeSpeedHeroPrice;

    private void Awake()
    {
        //upgradeDobleShootLevel = 1;
       // upgradeSpeedHeroLevel = 1;

        GameController.Instance.upgradeDobleShootLevel = upgradeDobleShootLevel;
        GameController.Instance.upgradeDobleShootPrice = upgradeDobleShootPrice;
        GameController.Instance.upgradeSpeedHeroLevel = upgradeSpeedHeroLevel;
        GameController.Instance.upgradeSpeedHeroPrice = upgradeSpeedHeroPrice;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
