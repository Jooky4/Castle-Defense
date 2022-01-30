using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// Скрипт весит на кнопке NEXT 
/// </summary>
public class LoadMarket : MonoBehaviour
{
    public void LoadSceneMarket()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   // текущая сцена
        SceneManager.LoadScene("SceneMarket");            // иначе текущая
    }
}
