//висит на игроке
// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// движение персонажа и анимаци€
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [Header("Rotate")]
    [SerializeField]
    private GameObject visualPlayer;

    [Header("Ќачальна€ скорость")]
    [SerializeField]
    private float speedBegin = 3.0f;

    [Header("«начение Upgrade скорости")]
    [SerializeField]
    private float multiPlay = 0.005f;

    private int upgradeSpeedHeroLevel;      //  // текущий Level SpeedHero

    private float speed;       // текуща€ скорость

    [Header("јниматор")]
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        upgradeSpeedHeroLevel = GameController.Instance.upgradeSpeedHeroLevel;
        speedBegin = speedBegin + upgradeSpeedHeroLevel * multiPlay;
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        speedBegin *= 2;
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

        if ((horizMove == 0.0f && verticalMove == 0.0f) || (GameController.Instance.stateGame != StateGame.Game))
        {
            if (animator)
            {
                animator.SetBool("Run", false);
                speed = 0;
                rigidBody.velocity =  Vector3.zero;
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

        // Vector3 movement = new Vector3(verticalMove, 0, horizMove) * speed;
        //transform.Translate(movement * Time.fixedDeltaTime);

        //speed *= 5;
        Vector3 movement = new Vector3(-horizMove, 0, verticalMove) * speed;
        //rigidBody.AddForce(movement);
        rigidBody.velocity = movement;
    }

}


