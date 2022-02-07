using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoneyBot : MonoBehaviour
{
    [SerializeField]
    private CheckBullet checkBullet;

    [SerializeField]
    private EnemyController enemyController;

    private TMP_Text  textMeshMoneyBot;


    void Start()
    {
        textMeshMoneyBot = GetComponent<TMP_Text>();
        textMeshMoneyBot.text = "";
    }

    void Update()
    {
        if (checkBullet.isDead)
        {
            textMeshMoneyBot.text = "+" + enemyController.moneyForBot.ToString();
        }
    }
}
