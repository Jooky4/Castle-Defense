using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoneyBot : MonoBehaviour
{
    [SerializeField]
    private CheckBullet checkBullet;

    [SerializeField]
    private EnemyController enemyController;

    private TextMesh textMeshMoneyBot;


    void Start()
    {
        textMeshMoneyBot = GetComponent<TextMesh>();
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
