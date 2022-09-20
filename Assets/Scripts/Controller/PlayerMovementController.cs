using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region Veriables
    [SerializeField] private Rigidbody rigidbody;
    [Header("Data")]
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float SidewaysSpeed = 2f;
    [ShowInInspector] private bool isReadyToMove = false;
    [ShowInInspector] private bool isPlayToMove = true;
    public FixedJoystick joystick;
    public PlayerAnimationController playerAnimationController;
    #endregion

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Play();
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
    #region PlayRunnerControls
    public void RunnerMove()
    {
        rigidbody.velocity = new Vector3(SidewaysSpeed * joystick.Horizontal, rigidbody.position.y, forwardSpeed);
        playerAnimationController.ResetAnim();
        playerAnimationController.RunAnim();

    }
    #endregion
    #region PlayIdleControls
    public void IdleMove()
    {
        rigidbody.velocity = Vector3.zero;
        playerAnimationController.IdleAnim();
    }
    #endregion

    #region PlayButtonIsMove
    public void Play()
    {
        isReadyToMove = true;
        isPlayToMove = false;
    }
    #endregion

    #endregion
}
