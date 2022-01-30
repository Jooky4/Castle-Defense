using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkinHero : MonoBehaviour
{
    [Header(" Массив префабов скинов")]
    [SerializeField]
    private Transform[] arrayPrefabsSkins;

    [SerializeField]
    private int indexIDSkin;

    private void Start()
    {
        indexIDSkin = GameController.Instance.currentIDSkin;

        for (int index = 0; index < arrayPrefabsSkins.Length;index++)
        {
            if (index == indexIDSkin)
            {
                arrayPrefabsSkins[index].gameObject.SetActive(true);
            }
            else
            {
                arrayPrefabsSkins[index].gameObject.SetActive(false);
            }
        }
    }
}

