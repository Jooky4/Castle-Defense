using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeSytem : MonoBehaviour
{
    [HideInInspector]
    public int upgradeDoubleShootLevel;
    [HideInInspector]
    public int upgradeSpeedHeroLevel;


    [Header("��������� ���� �������� DoubleShoot")]
    [SerializeField]
    private int startPriceDoubleShoot;
    [Header("��������� ���� �������� DoubleShoot")]
    [SerializeField]
    private int nextPriceDoubleShoot;

    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int startPriceSpeedHero;
    [Header("��������� ���� �������� SpeedHero")]
    [SerializeField]
    private int nextPriceSpeedHero;


    [SerializeField]
    private int upgradeDoubleShootPrice;
    [SerializeField]
    private int upgradeSpeedHeroPrice;
   


    void Start()
    {
        upgradeDoubleShootLevel = 0;
        upgradeSpeedHeroLevel = 0;
        GameController.Instance.upgradeDobleShootLevel = upgradeDoubleShootLevel;
        GameController.Instance.upgradeDobleShootPrice = upgradeDoubleShootPrice;
        GameController.Instance.upgradeSpeedHeroLevel = upgradeSpeedHeroLevel;
        GameController.Instance.upgradeSpeedHeroPrice = upgradeSpeedHeroPrice;
    }

    void Update()
    {

    }
}
