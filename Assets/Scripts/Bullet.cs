using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Header("Визуал пули")]
    private Transform visualBullet;

    [SerializeField]
    [Header("Система частиц")]
    private ParticleSystem particleSys;

    //[HideInInspector]
    public bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveController>())
        {
            visualBullet.gameObject.SetActive(false);
            Debug.Log(" Active false");
            if (particleSys)
            {
                particleSys.Play();
            }
        }
    }
}
