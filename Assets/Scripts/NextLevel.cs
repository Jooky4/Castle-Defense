using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// Скрипт весит на кнопке NEXT 
/// </summary>
public class NextLevel : MonoBehaviour
{
    public void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   // текущая сцена
        SceneManager.LoadScene(currentScene);            // иначе текущая
    }
}
