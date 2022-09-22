using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Veriables
    private Animator animator;
    #endregion

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void RunAnim()
    {
        animator.SetBool("run", true);
    }
    public void IdleAnim()
    {
        animator.SetBool("idle", true);
    }
    public void ResetAnim()
    {
        animator.SetBool("run", false);
        animator.SetBool("idle", false);
        animator.SetBool("crouch", false);
    }
    public void CrouchAnim()
    {
        animator.SetBool("crouch", true);
    }
}
