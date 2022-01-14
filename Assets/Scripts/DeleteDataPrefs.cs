using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDataPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" Delete all data");
        PlayerPrefs.DeleteAll();
    }

   
}
