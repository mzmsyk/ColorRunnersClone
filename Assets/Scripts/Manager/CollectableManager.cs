using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public CollectableAnimController collectableAnimController;
    //public static CollectableManager instance;


    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //collectableAnimController.CollectableIdleAnim();
    }

    public void CollectableRunAnim()
    {
        collectableAnimController.ResetAllAnim();
        collectableAnimController.CollectableRunAnim();
    }
    public void CollectableIdleAnim()
    {
        collectableAnimController.ResetAllAnim();
        collectableAnimController.CollectableIdleAnim();
    }
    public void ResetAllAnim()
    {

        collectableAnimController.ResetAllAnim();
    }
    public void CollectableCrouchAnim()
    {
        collectableAnimController.CollectableCrouchAnim();
    }
}
