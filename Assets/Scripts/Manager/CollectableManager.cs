using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public CollectableAnimController collectableAnimController;



    private void Awake()
    {
        //collectableAnimController.CollectableIdleAnim();
    }

    public void CollectableRunAnim()
    {
        collectableAnimController.ResetAllAnim();
        collectableAnimController.CollectableRunAnim();
    }
    public void CollectableIdleAnim()
    {
        collectableAnimController.CollectableIdleAnim();
    }
}
