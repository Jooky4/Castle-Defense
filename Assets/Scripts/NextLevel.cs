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
        // Debug.Log(" SceneManager.GetActiveScene().buildIndex  = " + SceneManager.GetActiveScene().buildIndex);
        //  Debug.Log(" sceneCountInBuildSettings  = " + SceneManager.sceneCountInBuildSettings);

        int currentScene = SceneManager.GetActiveScene().buildIndex;   // текущая сцена

        int countSceneInBuild = SceneManager.sceneCountInBuildSettings;   // количество сцен в BuildSettings

        SaveData("LevelNumber", GameController.Instance.currentLevel);   // сохраняем номер level

        SaveData("Money", GameController.Instance.currentMoney); // сохраняем колво денег
        

        if (countSceneInBuild - 1 > currentScene)          // если есь др сцены
        {
            SceneManager.LoadScene(currentScene + 1);         // то загружаем их
        }
        else
        {
            SceneManager.LoadScene(currentScene);            // иначе текущая
        }
    }

    /// <summary>
    /// Сохранение данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    public void SaveData(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }


    /// <summary>
    /// Загрузка данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadLevelNumber(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
