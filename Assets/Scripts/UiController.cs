using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
    [SerializeField]
    private Text TextCurrentHelth;

    [SerializeField]
    private Text TextCurrentTimer;

    // Update is called once per frame
    void Update()
    {
        TextCurrentHelth.text = GameController.Instance.currentHealthCastle.ToString();
        TextCurrentTimer.text = GameController.Instance.currentTimerGame.ToString();
    }
}
