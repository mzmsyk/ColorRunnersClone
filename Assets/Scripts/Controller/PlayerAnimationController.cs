using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
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
    }
}
