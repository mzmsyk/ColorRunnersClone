using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimController : MonoBehaviour
{
    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    public void CollectableRunAnim()
    {
        animator.SetBool("run", true);
    }
    public void CollectableIdleAnim()
    {
        animator.SetBool("idle", true);
    }
    public void ResetAllAnim()
    {
        animator.SetBool("run", false);
        animator.SetBool("idle", false);
    }
}
