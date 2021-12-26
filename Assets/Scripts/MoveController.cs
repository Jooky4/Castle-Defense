//висит на игроке
// движение персонажа
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    
    [Header("Rotate")]
    [SerializeField]
    private GameObject visualPlayer;

    [Header("Начальная скорость")]
    [SerializeField]
    private float speedBegin = 3.0f;

    private float speed;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
       //if (!GameController.Instance) return;
        Move();
    }

    /// <summary>
    /// двигаем игрока
    /// </summary>
    private void Move()
    {
        float horizMove = JoystickStick.Instance.VerticalAxis();
        float verticalMove = JoystickStick.Instance.HorizontalAxis(); 

        if (horizMove == 0.0f && verticalMove == 0.0f)
        {
            if (animator)
            {
                animator.SetBool("Run", false);
                speed = 0;
            }
            return;
        }
        else
        {
            speed = speedBegin;
        }

        float angle = Mathf.Atan2(verticalMove, horizMove) * Mathf.Rad2Deg;
        visualPlayer.transform.rotation = Quaternion.Euler(0, angle, 0);

        if (animator)
        {
            if (speed == speedBegin)
            {
                animator.SetBool("Run", true);
            }
          
        }

        Vector3 movement = new Vector3(verticalMove, 0, horizMove) * speed;

        transform.Translate(movement * Time.fixedDeltaTime);
    }

}


