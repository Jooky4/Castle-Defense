// ����� �� UiController
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ���������� UI
/// </summary>
public class UiController : MonoBehaviour
{
    [Header("C����� UI �������� �����")]
    [SerializeField]
    private TMP_Text textCurrentHelth;

    [Header("C����� UI ������")]
    [SerializeField]
    private TMP_Text textCurrentTimer;

    [Header("C����� UI Level PanelLose")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelLose;

    [Header("C����� UI Level PanelWin")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelWin;

    [Header("C����� UI ����� PanelWin")]
    [SerializeField]
    private TMP_Text textMoneyPanelWin;

    [Header("C����� UI ����� PanelLose")]
    [SerializeField]
    private TMP_Text textMoneyPanelLose;


    // Update is called once per frame
    void Update()
    {
        textCurrentHelth.text = GameController.Instance.currentHealthCastle.ToString();
        textCurrentTimer.text = GameController.Instance.currentTimerGame.ToString();
        textCurrentLevelPanelLose.text = GameController.Instance.currentLevel.ToString();
        textCurrentLevelPanelWin.text = GameController.Instance.currentLevel.ToString();
        textMoneyPanelWin.text = GameController.Instance.currentMoney.ToString();
        textMoneyPanelLose.text = GameController.Instance.currentMoney.ToString();

    }
}
