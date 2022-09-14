using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [Header("Data")] 
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float SidewaysSpeed = 2f;
    [ShowInInspector] private bool isReadyToMove = false;
    [ShowInInspector] private bool isPlayToMove = true;
    [SerializeField] private FixedJoystick joystick;
    public PlayerAnimationController playerAnimationController;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isReadyToMove = true;
            isPlayToMove = false;
        }
        if (isPlayToMove)
        {
            IdleMove();
        }
        if (isReadyToMove)
        {
            RunnerMove();
        }
    }
    #region  Functions
    public void RunnerMove()
    {
        rigidbody.velocity = new Vector3(SidewaysSpeed * joystick.Horizontal, rigidbody.position.y, forwardSpeed);
        playerAnimationController.ResetAnim();
        playerAnimationController.RunAnim();
    }
    public void IdleMove()
    {
        rigidbody.velocity = Vector3.zero;
        playerAnimationController.IdleAnim();
    }
    #endregion
}
