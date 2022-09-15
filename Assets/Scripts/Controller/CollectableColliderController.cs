using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CollectableColliderController : MonoBehaviour
{
    public CollectableMaterialsController collectableMaterialsController;
    public CollectableManager collectableManager;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Player")
        {
            
            //collectableMaterialsController.ChangeColorState(collectableMaterialsController.colorEnums);
            Debug.Log("color");
            collectableMaterialsController.CollectableMeshControl(this.transform);
            collectableManager.CollectableRunAnim();
        }
    }
    
}
