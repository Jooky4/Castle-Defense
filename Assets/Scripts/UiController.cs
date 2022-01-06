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
    private Text textCurrentHelth;

    [Header("C����� UI ������")]
    [SerializeField]
    private Text textCurrentTimer;

    [Header("C����� UI Level PanelLose")]
    [SerializeField]
    private TMP_Text textCurrentLevelPanelLose;

    [Header("C����� UI Level PanelWin")]
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
