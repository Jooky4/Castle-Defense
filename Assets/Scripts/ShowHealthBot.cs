using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthBot : MonoBehaviour
{
    [SerializeField]
    private CheckBullet checkBullet;

    private TextMesh textMeshHealthBot;


    void Start()
    {
        textMeshHealthBot = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshHealthBot.text = checkBullet.currentHealthBot.ToString();
    }
}
