using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneColliderController : MonoBehaviour
{
    public PlayerMovementController playerMovementController;
    public PlayerAnimationController playerAnimationController;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Player"|| col.gameObject.tag == "Collectable")
        {
            playerMovementController.StopMove();
            playerAnimationController.ResetAnim();
            playerAnimationController.CrouchAnim();
        }
    }
}
