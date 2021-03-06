//????? ?? ??????
// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ???????? ????????? ? ????????
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [Header("Rotate")]
    [SerializeField]
    private GameObject visualPlayer;

    [Header("????????? ????????")]
    [SerializeField]
    private float speedBegin = 3.0f;

    [Header("???????? Upgrade ????????")]
    [SerializeField]
    private float multiPlay = 0.005f;

    private int upgradeSpeedHeroLevel;      //  // ??????? Level SpeedHero

    private float speed;       // ??????? ????????

    [Header("????????")]
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
    /// ??????? ??????
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


