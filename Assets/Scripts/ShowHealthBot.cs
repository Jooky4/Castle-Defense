using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHealthBot : MonoBehaviour
{
    [SerializeField]
    private CheckBullet checkBullet;

    //private TextMesh textMeshHealthBot;
    private TMP_Text textMeshHealthBot;


    void Start()
    {
        textMeshHealthBot = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshHealthBot.text = checkBullet.currentHealthBot.ToString();
    }
}
