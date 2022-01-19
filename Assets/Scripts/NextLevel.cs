using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ������ ����� �� ������ NEXT 
/// </summary>
public class NextLevel : MonoBehaviour
{
    public void LoadScene()
    {
        // Debug.Log(" SceneManager.GetActiveScene().buildIndex  = " + SceneManager.GetActiveScene().buildIndex);
        //  Debug.Log(" sceneCountInBuildSettings  = " + SceneManager.sceneCountInBuildSettings);

        int currentScene = SceneManager.GetActiveScene().buildIndex;   // ������� �����

        int countSceneInBuild = SceneManager.sceneCountInBuildSettings;   // ���������� ���� � BuildSettings

        SaveData("LevelNumber", GameController.Instance.currentLevel);   // ��������� ����� level

        SaveData("Money", GameController.Instance.currentMoney); // ��������� ����� �����
        

        if (countSceneInBuild - 1 > currentScene)          // ���� ��� �� �����
        {
            SceneManager.LoadScene(currentScene + 1);         // �� ��������� ��
        }
        else
        {
            SceneManager.LoadScene(currentScene);            // ����� �������
        }
    }

    /// <summary>
    /// ���������� ������
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    public void SaveData(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }


    /// <summary>
    /// �������� ������
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadLevelNumber(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
