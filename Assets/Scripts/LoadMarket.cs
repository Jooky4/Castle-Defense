using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// ������ ����� �� ������ NEXT 
/// </summary>
public class LoadMarket : MonoBehaviour
{
    public void LoadSceneMarket()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;   // ������� �����
        SceneManager.LoadScene("SceneMarket");            // ����� �������
    }
}
