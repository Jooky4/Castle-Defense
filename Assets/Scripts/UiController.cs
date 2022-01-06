// висит на UiController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Обновление UI
/// </summary>
public class UiController : MonoBehaviour
{
    [Header("Cсылка UI здоровья замка")]
    [SerializeField]
    private Text textCurrentHelth;

    [Header("Cсылка UI таймер")]
    [SerializeField]
    private Text textCurrentTimer;

    [Header("Cсылка UI Level PanelLose")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelLose;

    [Header("Cсылка UI Level PanelWin")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelWin;

    // Update is called once per frame
    void Update()
    {
        textCurrentHelth.text = GameController.Instance.currentHealthCastle.ToString();
        textCurrentTimer.text = GameController.Instance.currentTimerGame.ToString();
        textCurrentLevelPanelLose.text = GameController.Instance.currentLevel.ToString();
        textCurrentLevelPanelWin.text = GameController.Instance.currentLevel.ToString();

    }
}
